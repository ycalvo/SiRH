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
    public class CATEGORIASController : Controller
    {
        private DB_RHumanosEntities db = new DB_RHumanosEntities();

        // GET: CATEGORIAS
        public async Task<ActionResult> Index()
        {
            return View(await db.CATEGORIAS.ToListAsync());
        }

        // GET: CATEGORIAS/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIAS cATEGORIAS = await db.CATEGORIAS.FindAsync(id);
            if (cATEGORIAS == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIAS);
        }

        // GET: CATEGORIAS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CATEGORIAS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_CATEGORIA,CATDESCRIPCION")] CATEGORIAS cATEGORIAS)
        {
            if (ModelState.IsValid)
            {
                db.CATEGORIAS.Add(cATEGORIAS);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cATEGORIAS);
        }

        // GET: CATEGORIAS/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIAS cATEGORIAS = await db.CATEGORIAS.FindAsync(id);
            if (cATEGORIAS == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIAS);
        }

        // POST: CATEGORIAS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_CATEGORIA,CATDESCRIPCION")] CATEGORIAS cATEGORIAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cATEGORIAS).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cATEGORIAS);
        }

        // GET: CATEGORIAS/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIAS cATEGORIAS = await db.CATEGORIAS.FindAsync(id);
            if (cATEGORIAS == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIAS);
        }

        // POST: CATEGORIAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CATEGORIAS cATEGORIAS = await db.CATEGORIAS.FindAsync(id);
            db.CATEGORIAS.Remove(cATEGORIAS);
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
