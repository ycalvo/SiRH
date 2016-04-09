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
    public class BENEFICIOSController : Controller
    {
        private DB_RHumanosEntities db = new DB_RHumanosEntities();

        // GET: BENEFICIOS
        public async Task<ActionResult> Index()
        {
            return View(await db.BENEFICIOS.ToListAsync());
        }

        // GET: BENEFICIOS/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BENEFICIOS bENEFICIOS = await db.BENEFICIOS.FindAsync(id);
            if (bENEFICIOS == null)
            {
                return HttpNotFound();
            }
            return View(bENEFICIOS);
        }

        // GET: BENEFICIOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BENEFICIOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_BENEFICIO,BENDESCRIPCION")] BENEFICIOS bENEFICIOS)
        {
            if (ModelState.IsValid)
            {
                db.BENEFICIOS.Add(bENEFICIOS);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(bENEFICIOS);
        }

        // GET: BENEFICIOS/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BENEFICIOS bENEFICIOS = await db.BENEFICIOS.FindAsync(id);
            if (bENEFICIOS == null)
            {
                return HttpNotFound();
            }
            return View(bENEFICIOS);
        }

        // POST: BENEFICIOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_BENEFICIO,BENDESCRIPCION")] BENEFICIOS bENEFICIOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bENEFICIOS).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bENEFICIOS);
        }

        // GET: BENEFICIOS/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BENEFICIOS bENEFICIOS = await db.BENEFICIOS.FindAsync(id);
            if (bENEFICIOS == null)
            {
                return HttpNotFound();
            }
            return View(bENEFICIOS);
        }

        // POST: BENEFICIOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BENEFICIOS bENEFICIOS = await db.BENEFICIOS.FindAsync(id);
            db.BENEFICIOS.Remove(bENEFICIOS);
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
