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
using StockInventory.CustomAttributes;

namespace StockInventory.Controllers
{
    [SessionAuthorize]
    public class CityController : Controller
    {
        private StockInventoryContext db = new StockInventoryContext();

        // GET: City
        public async Task<ActionResult> Index()
        {
            var city = db.City.Include(c => c.Region);
            return View(await city.ToListAsync());
        }

        // GET: City/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = await db.City.FindAsync(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // GET: City/Create
        public ActionResult Create()
        {
            ViewBag.RegionID = new SelectList(db.Region, "ID", "Name");
            return View();
        }

        // POST: City/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,RegionID")] City city)
        {
            if (ModelState.IsValid)
            {
                city.ID = Guid.NewGuid();
                db.City.Add(city);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RegionID = new SelectList(db.Region, "ID", "Name", city.RegionID);
            return View(city);
        }

        // GET: City/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = await db.City.FindAsync(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegionID = new SelectList(db.Region, "ID", "Name", city.RegionID);
            return View(city);
        }

        // POST: City/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,RegionID")] City city)
        {
            if (ModelState.IsValid)
            {
                db.Entry(city).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RegionID = new SelectList(db.Region, "ID", "Name", city.RegionID);
            return View(city);
        }

        // GET: City/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = await db.City.FindAsync(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // POST: City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            City city = await db.City.FindAsync(id);
            db.City.Remove(city);
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
