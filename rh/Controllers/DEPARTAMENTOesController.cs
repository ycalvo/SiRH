using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using rh.Data;

namespace rh.Controllers
{
    public class DEPARTAMENTOesController : Controller
    {
        private DB_RHumanosEntities db = new DB_RHumanosEntities();

        // GET: DEPARTAMENTOes
        public async Task<ActionResult> Index()
        {
            return View(await db.DEPARTAMENTO.ToListAsync());
        }

        // GET: DEPARTAMENTOes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTAMENTO dEPARTAMENTO = await db.DEPARTAMENTO.FindAsync(id);
            if (dEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(dEPARTAMENTO);
        }

        // GET: DEPARTAMENTOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DEPARTAMENTOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_DEPARTAMENTO,DEPARTAMENTO1")] DEPARTAMENTO dEPARTAMENTO)
        {
            if (ModelState.IsValid)
            {
                db.DEPARTAMENTO.Add(dEPARTAMENTO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(dEPARTAMENTO);
        }

        // GET: DEPARTAMENTOes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTAMENTO dEPARTAMENTO = await db.DEPARTAMENTO.FindAsync(id);
            if (dEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(dEPARTAMENTO);
        }

        // POST: DEPARTAMENTOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_DEPARTAMENTO,DEPARTAMENTO1")] DEPARTAMENTO dEPARTAMENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dEPARTAMENTO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dEPARTAMENTO);
        }

        // GET: DEPARTAMENTOes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTAMENTO dEPARTAMENTO = await db.DEPARTAMENTO.FindAsync(id);
            if (dEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(dEPARTAMENTO);
        }

        // POST: DEPARTAMENTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DEPARTAMENTO dEPARTAMENTO = await db.DEPARTAMENTO.FindAsync(id);
            db.DEPARTAMENTO.Remove(dEPARTAMENTO);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
