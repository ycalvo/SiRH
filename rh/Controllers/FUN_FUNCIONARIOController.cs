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
    public class FUN_FUNCIONARIOController : Controller
    {
        private DB_RHumanosEntities db = new DB_RHumanosEntities();

        // GET: FUN_FUNCIONARIO
        public async Task<ActionResult> Index()
        {
            var fUN_FUNCIONARIO = db.FUN_FUNCIONARIO.Include(f => f.FUNCIONES);
            return View(await fUN_FUNCIONARIO.ToListAsync());
        }

        // GET: FUN_FUNCIONARIO/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FUN_FUNCIONARIO fUN_FUNCIONARIO = await db.FUN_FUNCIONARIO.FindAsync(id);
            if (fUN_FUNCIONARIO == null)
            {
                return HttpNotFound();
            }
            return View(fUN_FUNCIONARIO);
        }

        // GET: FUN_FUNCIONARIO/Create
        public ActionResult Create()
        {
            ViewBag.ID_FUNCIONES = new SelectList(db.FUNCIONES, "ID_FUNCIONES", "FUNCDESCRIPCION");
            return View();
        }

        // POST: FUN_FUNCIONARIO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_FUNCIONARIO,ID_FUNCIONES")] FUN_FUNCIONARIO fUN_FUNCIONARIO)
        {
            if (ModelState.IsValid)
            {
                db.FUN_FUNCIONARIO.Add(fUN_FUNCIONARIO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_FUNCIONES = new SelectList(db.FUNCIONES, "ID_FUNCIONES", "FUNCDESCRIPCION", fUN_FUNCIONARIO.ID_FUNCIONES);
            return View(fUN_FUNCIONARIO);
        }

        // GET: FUN_FUNCIONARIO/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FUN_FUNCIONARIO fUN_FUNCIONARIO = await db.FUN_FUNCIONARIO.FindAsync(id);
            if (fUN_FUNCIONARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_FUNCIONES = new SelectList(db.FUNCIONES, "ID_FUNCIONES", "FUNCDESCRIPCION", fUN_FUNCIONARIO.ID_FUNCIONES);
            return View(fUN_FUNCIONARIO);
        }

        // POST: FUN_FUNCIONARIO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_FUNCIONARIO,ID_FUNCIONES")] FUN_FUNCIONARIO fUN_FUNCIONARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fUN_FUNCIONARIO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_FUNCIONES = new SelectList(db.FUNCIONES, "ID_FUNCIONES", "FUNCDESCRIPCION", fUN_FUNCIONARIO.ID_FUNCIONES);
            return View(fUN_FUNCIONARIO);
        }

        // GET: FUN_FUNCIONARIO/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FUN_FUNCIONARIO fUN_FUNCIONARIO = await db.FUN_FUNCIONARIO.FindAsync(id);
            if (fUN_FUNCIONARIO == null)
            {
                return HttpNotFound();
            }
            return View(fUN_FUNCIONARIO);
        }

        // POST: FUN_FUNCIONARIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FUN_FUNCIONARIO fUN_FUNCIONARIO = await db.FUN_FUNCIONARIO.FindAsync(id);
            db.FUN_FUNCIONARIO.Remove(fUN_FUNCIONARIO);
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
