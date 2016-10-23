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
    public class LionsController : Controller
    {
        private LionDatabaseEntities db = new LionDatabaseEntities();

        // GET: Lions
        public async Task<ActionResult> Index()
        {
            return View(await db.Lions.ToListAsync());
        }

        // GET: Lions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lion lion = await db.Lions.FindAsync(id);
            if (lion == null)
            {
                return HttpNotFound();
            }
            return View(lion);
        }

        // GET: Lions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,Age,Weight,Gender,Country")] Lion lion)
        {
            if (ModelState.IsValid)
            {
                db.Lions.Add(lion);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(lion);
        }

        // GET: Lions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lion lion = await db.Lions.FindAsync(id);
            if (lion == null)
            {
                return HttpNotFound();
            }
            return View(lion);
        }

        // POST: Lions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Age,Weight,Gender,Country")] Lion lion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lion).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(lion);
        }

        // GET: Lions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lion lion = await db.Lions.FindAsync(id);
            if (lion == null)
            {
                return HttpNotFound();
            }
            return View(lion);
        }

        // POST: Lions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Lion lion = await db.Lions.FindAsync(id);
            db.Lions.Remove(lion);
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
