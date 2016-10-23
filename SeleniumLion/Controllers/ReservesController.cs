using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SeleniumLion.Models.EF;

namespace SeleniumLion.Controllers
{
    public class ReservesController : Controller
    {
        private LionDatabaseEntities db = new LionDatabaseEntities();

        // GET: Reserves
        public async Task<ActionResult> Index()
        {
            return View(await db.Reserves.ToListAsync());
        }

        // GET: Reserves/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserve reserve = await db.Reserves.FindAsync(id);
            if (reserve == null)
            {
                return HttpNotFound();
            }
            return View(reserve);
        }

        // GET: Reserves/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reserves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,Location")] Reserve reserve)
        {
            if (ModelState.IsValid)
            {
                db.Reserves.Add(reserve);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(reserve);
        }

        // GET: Reserves/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserve reserve = await db.Reserves.FindAsync(id);
            if (reserve == null)
            {
                return HttpNotFound();
            }
            return View(reserve);
        }

        // POST: Reserves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Location")] Reserve reserve)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserve).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(reserve);
        }

        // GET: Reserves/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserve reserve = await db.Reserves.FindAsync(id);
            if (reserve == null)
            {
                return HttpNotFound();
            }
            return View(reserve);
        }

        // POST: Reserves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Reserve reserve = await db.Reserves.FindAsync(id);
            db.Reserves.Remove(reserve);
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
