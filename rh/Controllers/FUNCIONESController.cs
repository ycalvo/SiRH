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
    public class FUNCIONESController : Controller
    {
        private DB_RHumanosEntities db = new DB_RHumanosEntities();

        // GET: FUNCIONES
        public async Task<ActionResult> Index()
        {
            return View(await db.FUNCIONES.ToListAsync());
        }

        // GET: FUNCIONES/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FUNCIONES fUNCIONES = await db.FUNCIONES.FindAsync(id);
            if (fUNCIONES == null)
            {
                return HttpNotFound();
            }
            return View(fUNCIONES);
        }

        // GET: FUNCIONES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FUNCIONES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_FUNCIONES,FUNCDESCRIPCION")] FUNCIONES fUNCIONES)
        {
            if (ModelState.IsValid)
            {
                db.FUNCIONES.Add(fUNCIONES);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(fUNCIONES);
        }

        // GET: FUNCIONES/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FUNCIONES fUNCIONES = await db.FUNCIONES.FindAsync(id);
            if (fUNCIONES == null)
            {
                return HttpNotFound();
            }
            return View(fUNCIONES);
        }

        // POST: FUNCIONES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_FUNCIONES,FUNCDESCRIPCION")] FUNCIONES fUNCIONES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fUNCIONES).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(fUNCIONES);
        }

        // GET: FUNCIONES/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FUNCIONES fUNCIONES = await db.FUNCIONES.FindAsync(id);
            if (fUNCIONES == null)
            {
                return HttpNotFound();
            }
            return View(fUNCIONES);
        }

        // POST: FUNCIONES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FUNCIONES fUNCIONES = await db.FUNCIONES.FindAsync(id);
            db.FUNCIONES.Remove(fUNCIONES);
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
