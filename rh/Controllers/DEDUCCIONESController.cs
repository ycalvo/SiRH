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
    public class DEDUCCIONESController : Controller
    {
        private DB_RHumanosEntities db = new DB_RHumanosEntities();

        // GET: DEDUCCIONES
        public async Task<ActionResult> Index()
        {
            return View(await db.DEDUCCIONES.ToListAsync());
        }

        // GET: DEDUCCIONES/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEDUCCIONES dEDUCCIONES = await db.DEDUCCIONES.FindAsync(id);
            if (dEDUCCIONES == null)
            {
                return HttpNotFound();
            }
            return View(dEDUCCIONES);
        }

        // GET: DEDUCCIONES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DEDUCCIONES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_DEDUCCION,DEDDESCRIPCION")] DEDUCCIONES dEDUCCIONES)
        {
            if (ModelState.IsValid)
            {
                db.DEDUCCIONES.Add(dEDUCCIONES);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(dEDUCCIONES);
        }

        // GET: DEDUCCIONES/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEDUCCIONES dEDUCCIONES = await db.DEDUCCIONES.FindAsync(id);
            if (dEDUCCIONES == null)
            {
                return HttpNotFound();
            }
            return View(dEDUCCIONES);
        }

        // POST: DEDUCCIONES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_DEDUCCION,DEDDESCRIPCION")] DEDUCCIONES dEDUCCIONES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dEDUCCIONES).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dEDUCCIONES);
        }

        // GET: DEDUCCIONES/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEDUCCIONES dEDUCCIONES = await db.DEDUCCIONES.FindAsync(id);
            if (dEDUCCIONES == null)
            {
                return HttpNotFound();
            }
            return View(dEDUCCIONES);
        }

        // POST: DEDUCCIONES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DEDUCCIONES dEDUCCIONES = await db.DEDUCCIONES.FindAsync(id);
            db.DEDUCCIONES.Remove(dEDUCCIONES);
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
