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
    public class DETALLEPLATILLADEDsController : Controller
    {
        private DB_RHumanosEntities db = new DB_RHumanosEntities();

        // GET: DETALLEPLATILLADEDs
        public async Task<ActionResult> Index()
        {
            var dETALLEPLATILLADED = db.DETALLEPLATILLADED.Include(d => d.DETALLEPLATILLADED1).Include(d => d.DETALLEPLATILLADED2);
            return View(await dETALLEPLATILLADED.ToListAsync());
        }

        // GET: DETALLEPLATILLADEDs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLEPLATILLADED dETALLEPLATILLADED = await db.DETALLEPLATILLADED.FindAsync(id);
            if (dETALLEPLATILLADED == null)
            {
                return HttpNotFound();
            }
            return View(dETALLEPLATILLADED);
        }

        // GET: DETALLEPLATILLADEDs/Create
        public ActionResult Create()
        {
            ViewBag.ID_PLANILLA = new SelectList(db.DETALLEPLATILLADED, "ID_PLANILLA", "ID_PLANILLA");
            ViewBag.ID_PLANILLA = new SelectList(db.DETALLEPLATILLADED, "ID_PLANILLA", "ID_PLANILLA");
            return View();
        }

        // POST: DETALLEPLATILLADEDs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_PLANILLA,ID_FUNCIONARIO,ID_DEDUCCION,MONTO")] DETALLEPLATILLADED dETALLEPLATILLADED)
        {
            if (ModelState.IsValid)
            {
                db.DETALLEPLATILLADED.Add(dETALLEPLATILLADED);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PLANILLA = new SelectList(db.DETALLEPLATILLADED, "ID_PLANILLA", "ID_PLANILLA", dETALLEPLATILLADED.ID_PLANILLA);
            ViewBag.ID_PLANILLA = new SelectList(db.DETALLEPLATILLADED, "ID_PLANILLA", "ID_PLANILLA", dETALLEPLATILLADED.ID_PLANILLA);
            return View(dETALLEPLATILLADED);
        }

        // GET: DETALLEPLATILLADEDs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLEPLATILLADED dETALLEPLATILLADED = await db.DETALLEPLATILLADED.FindAsync(id);
            if (dETALLEPLATILLADED == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PLANILLA = new SelectList(db.DETALLEPLATILLADED, "ID_PLANILLA", "ID_PLANILLA", dETALLEPLATILLADED.ID_PLANILLA);
            ViewBag.ID_PLANILLA = new SelectList(db.DETALLEPLATILLADED, "ID_PLANILLA", "ID_PLANILLA", dETALLEPLATILLADED.ID_PLANILLA);
            return View(dETALLEPLATILLADED);
        }

        // POST: DETALLEPLATILLADEDs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_PLANILLA,ID_FUNCIONARIO,ID_DEDUCCION,MONTO")] DETALLEPLATILLADED dETALLEPLATILLADED)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dETALLEPLATILLADED).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PLANILLA = new SelectList(db.DETALLEPLATILLADED, "ID_PLANILLA", "ID_PLANILLA", dETALLEPLATILLADED.ID_PLANILLA);
            ViewBag.ID_PLANILLA = new SelectList(db.DETALLEPLATILLADED, "ID_PLANILLA", "ID_PLANILLA", dETALLEPLATILLADED.ID_PLANILLA);
            return View(dETALLEPLATILLADED);
        }

        // GET: DETALLEPLATILLADEDs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLEPLATILLADED dETALLEPLATILLADED = await db.DETALLEPLATILLADED.FindAsync(id);
            if (dETALLEPLATILLADED == null)
            {
                return HttpNotFound();
            }
            return View(dETALLEPLATILLADED);
        }

        // POST: DETALLEPLATILLADEDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DETALLEPLATILLADED dETALLEPLATILLADED = await db.DETALLEPLATILLADED.FindAsync(id);
            db.DETALLEPLATILLADED.Remove(dETALLEPLATILLADED);
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
