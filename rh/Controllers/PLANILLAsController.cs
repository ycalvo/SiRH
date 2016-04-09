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
    public class PLANILLAsController : Controller
    {
        private DB_RHumanosEntities db = new DB_RHumanosEntities();

        // GET: PLANILLAs
        public async Task<ActionResult> Index()
        {
            return View(await db.PLANILLA.ToListAsync());
        }

        // GET: PLANILLAs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLANILLA pLANILLA = await db.PLANILLA.FindAsync(id);
            if (pLANILLA == null)
            {
                return HttpNotFound();
            }
            return View(pLANILLA);
        }

        // GET: PLANILLAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PLANILLAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_PLANILLA,PLAFECHA,SEDE,PLATOTAL")] PLANILLA pLANILLA)
        {
            if (ModelState.IsValid)
            {
                db.PLANILLA.Add(pLANILLA);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pLANILLA);
        }

        // GET: PLANILLAs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLANILLA pLANILLA = await db.PLANILLA.FindAsync(id);
            if (pLANILLA == null)
            {
                return HttpNotFound();
            }
            return View(pLANILLA);
        }

        // POST: PLANILLAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_PLANILLA,PLAFECHA,SEDE,PLATOTAL")] PLANILLA pLANILLA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pLANILLA).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pLANILLA);
        }

        // GET: PLANILLAs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLANILLA pLANILLA = await db.PLANILLA.FindAsync(id);
            if (pLANILLA == null)
            {
                return HttpNotFound();
            }
            return View(pLANILLA);
        }

        // POST: PLANILLAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PLANILLA pLANILLA = await db.PLANILLA.FindAsync(id);
            db.PLANILLA.Remove(pLANILLA);
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
