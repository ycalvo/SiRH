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
    public class DETALLEPLANILLABENsController : Controller
    {
        private DB_RHumanosEntities db = new DB_RHumanosEntities();

        // GET: DETALLEPLANILLABENs
        public async Task<ActionResult> Index()
        {
            var dETALLEPLANILLABEN = db.DETALLEPLANILLABEN.Include(d => d.DETALLEPLANILLABEN1).Include(d => d.DETALLEPLANILLABEN2);
            return View(await dETALLEPLANILLABEN.ToListAsync());
        }

        // GET: DETALLEPLANILLABENs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLEPLANILLABEN dETALLEPLANILLABEN = await db.DETALLEPLANILLABEN.FindAsync(id);
            if (dETALLEPLANILLABEN == null)
            {
                return HttpNotFound();
            }
            return View(dETALLEPLANILLABEN);
        }

        // GET: DETALLEPLANILLABENs/Create
        public ActionResult Create()
        {
            ViewBag.ID_PLANILLA = new SelectList(db.DETALLEPLANILLABEN, "ID_PLANILLA", "ID_BENEFICIO");
            ViewBag.ID_PLANILLA = new SelectList(db.DETALLEPLANILLABEN, "ID_PLANILLA", "ID_BENEFICIO");
            return View();
        }

        // POST: DETALLEPLANILLABENs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_PLANILLA,ID_FUNCIONARIO,ID_BENEFICIO,MONTO")] DETALLEPLANILLABEN dETALLEPLANILLABEN)
        {
            if (ModelState.IsValid)
            {
                db.DETALLEPLANILLABEN.Add(dETALLEPLANILLABEN);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PLANILLA = new SelectList(db.DETALLEPLANILLABEN, "ID_PLANILLA", "ID_BENEFICIO", dETALLEPLANILLABEN.ID_PLANILLA);
            ViewBag.ID_PLANILLA = new SelectList(db.DETALLEPLANILLABEN, "ID_PLANILLA", "ID_BENEFICIO", dETALLEPLANILLABEN.ID_PLANILLA);
            return View(dETALLEPLANILLABEN);
        }

        // GET: DETALLEPLANILLABENs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLEPLANILLABEN dETALLEPLANILLABEN = await db.DETALLEPLANILLABEN.FindAsync(id);
            if (dETALLEPLANILLABEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PLANILLA = new SelectList(db.DETALLEPLANILLABEN, "ID_PLANILLA", "ID_BENEFICIO", dETALLEPLANILLABEN.ID_PLANILLA);
            ViewBag.ID_PLANILLA = new SelectList(db.DETALLEPLANILLABEN, "ID_PLANILLA", "ID_BENEFICIO", dETALLEPLANILLABEN.ID_PLANILLA);
            return View(dETALLEPLANILLABEN);
        }

        // POST: DETALLEPLANILLABENs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_PLANILLA,ID_FUNCIONARIO,ID_BENEFICIO,MONTO")] DETALLEPLANILLABEN dETALLEPLANILLABEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dETALLEPLANILLABEN).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PLANILLA = new SelectList(db.DETALLEPLANILLABEN, "ID_PLANILLA", "ID_BENEFICIO", dETALLEPLANILLABEN.ID_PLANILLA);
            ViewBag.ID_PLANILLA = new SelectList(db.DETALLEPLANILLABEN, "ID_PLANILLA", "ID_BENEFICIO", dETALLEPLANILLABEN.ID_PLANILLA);
            return View(dETALLEPLANILLABEN);
        }

        // GET: DETALLEPLANILLABENs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLEPLANILLABEN dETALLEPLANILLABEN = await db.DETALLEPLANILLABEN.FindAsync(id);
            if (dETALLEPLANILLABEN == null)
            {
                return HttpNotFound();
            }
            return View(dETALLEPLANILLABEN);
        }

        // POST: DETALLEPLANILLABENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DETALLEPLANILLABEN dETALLEPLANILLABEN = await db.DETALLEPLANILLABEN.FindAsync(id);
            db.DETALLEPLANILLABEN.Remove(dETALLEPLANILLABEN);
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
