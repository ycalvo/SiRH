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
    public class TBFUNCIONARIOsController : Controller
    {
        private DB_RHumanosEntities db = new DB_RHumanosEntities();

        // GET: TBFUNCIONARIOs
        public async Task<ActionResult> Index()
        {
            return View(await db.TBFUNCIONARIO.ToListAsync());
        }

        // GET: TBFUNCIONARIOs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBFUNCIONARIO tBFUNCIONARIO = await db.TBFUNCIONARIO.FindAsync(id);
            if (tBFUNCIONARIO == null)
            {
                return HttpNotFound();
            }
            return View(tBFUNCIONARIO);
        }

        // GET: TBFUNCIONARIOs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TBFUNCIONARIOs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_FUNCIONARIO,FUNNOMBRE,FUNAPELLIDO1,FUNAPELLIDO2")] TBFUNCIONARIO tBFUNCIONARIO)
        {
            if (ModelState.IsValid)
            {
                db.TBFUNCIONARIO.Add(tBFUNCIONARIO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tBFUNCIONARIO);
        }

        // GET: TBFUNCIONARIOs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBFUNCIONARIO tBFUNCIONARIO = await db.TBFUNCIONARIO.FindAsync(id);
            if (tBFUNCIONARIO == null)
            {
                return HttpNotFound();
            }
            return View(tBFUNCIONARIO);
        }

        // POST: TBFUNCIONARIOs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_FUNCIONARIO,FUNNOMBRE,FUNAPELLIDO1,FUNAPELLIDO2")] TBFUNCIONARIO tBFUNCIONARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBFUNCIONARIO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tBFUNCIONARIO);
        }

        // GET: TBFUNCIONARIOs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBFUNCIONARIO tBFUNCIONARIO = await db.TBFUNCIONARIO.FindAsync(id);
            if (tBFUNCIONARIO == null)
            {
                return HttpNotFound();
            }
            return View(tBFUNCIONARIO);
        }

        // POST: TBFUNCIONARIOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TBFUNCIONARIO tBFUNCIONARIO = await db.TBFUNCIONARIO.FindAsync(id);
            db.TBFUNCIONARIO.Remove(tBFUNCIONARIO);
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
