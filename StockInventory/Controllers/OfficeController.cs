using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StockInventory.Models;

namespace StockInventory.Controllers
{
    public class OfficeController : Controller
    {
        private StockInventoryContext db = new StockInventoryContext();

        // GET: Office
        public async Task<ActionResult> Index()
        {
            var office = db.Office.Include(o => o.City);
            return View(await office.ToListAsync());
        }

        // GET: Office/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Office office = await db.Office.FindAsync(id);
            if (office == null)
            {
                return HttpNotFound();
            }
            return View(office);
        }

        // GET: Office/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.City, "ID", "Name");
            return View();
        }

        // POST: Office/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Code,Direction,CityID")] Office office)
        {
            if (ModelState.IsValid)
            {
                office.ID = Guid.NewGuid();
                db.Office.Add(office);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.City, "ID", "Name", office.CityID);
            return View(office);
        }

        // GET: Office/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Office office = await db.Office.FindAsync(id);
            if (office == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.City, "ID", "Name", office.CityID);
            return View(office);
        }

        // POST: Office/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Code,Direction,CityID")] Office office)
        {
            if (ModelState.IsValid)
            {
                db.Entry(office).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.City, "ID", "Name", office.CityID);
            return View(office);
        }

        // GET: Office/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Office office = await db.Office.FindAsync(id);
            if (office == null)
            {
                return HttpNotFound();
            }
            return View(office);
        }

        // POST: Office/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Office office = await db.Office.FindAsync(id);
            db.Office.Remove(office);
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
