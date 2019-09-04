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
    public class ItemController : Controller
    {
        private StockInventoryContext db = new StockInventoryContext();

        // GET: Item
        public async Task<ActionResult> Index()
        {
            var item = db.Item
                        .Include(i => i.Department)
                        .Include(e => e.Employee);
            return View(await item.ToListAsync());
        }

        // GET: Item/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Item.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Department, "ID", "Type");
            return View();
        }

        // POST: Item/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Type,Marca,Model,Status,Observation,DepartmentID")] Item item)
        {
            if (ModelState.IsValid)
            {
                item.ID = Guid.NewGuid();
                db.Item.Add(item);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.Department, "ID", "Type", item.DepartmentID);
            return View(item);
        }

        // GET: Item/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Item.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Department, "ID", "Type", item.DepartmentID);
            return View(item);
        }

        // POST: Item/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Type,Marca,Model,Status,Observation,DepartmentID")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Department, "ID", "Type", item.DepartmentID);
            return View(item);
        }
        
        // GET: Item/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Item.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Item item = await db.Item.FindAsync(id);
            db.Item.Remove(item);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Item/Assign/5
        public async Task<ActionResult> Assign(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Item.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            var employees = db.Employee.ToList();
            List<object> selectListEmployees = new List<object>();
            foreach (var employee in employees)
                selectListEmployees.Add(new
                {
                    Id = employee.ID,
                    Name = employee.Cedula + " - " + employee.FirstName + " " + employee.LastName
                });
            ViewBag.EmployeeID = new SelectList(selectListEmployees, "Id", "Name");
            ViewBag.RegionID = new SelectList(db.Region, "ID", "Name");
            ViewBag.CityID = new SelectList(db.City, "ID", "Name");
            ViewBag.DepartmentID = new SelectList(db.Department, "ID", "Type");
            return View(item);
        }

        // POST: Item/EditAssign/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Assign([Bind(Include = "ID,Type,Marca,Model,Status,Observation,DepartmentID,EmployeeID")] Item item)
        {
            if (ModelState.IsValid && item.EmployeeID != null)
            {
                Item itemToUpdate = db.Item.FirstOrDefault(i => i.ID == item.ID);
                itemToUpdate.EmployeeID = item.EmployeeID;
                db.Entry(itemToUpdate).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            var employees = db.Employee.ToList();
            List<object> selectListEmployees = new List<object>();
            foreach (var employee in employees)
                selectListEmployees.Add(new
                {
                    Id = employee.ID,
                    Name = employee.Cedula + " - " + employee.FirstName + " " + employee.LastName
                });
            ViewBag.EmployeeID = new SelectList(selectListEmployees, "Id", "Name");
            ViewBag.RegionID = new SelectList(db.Region, "ID", "Name");
            ViewBag.CityID = new SelectList(db.City, "ID", "Name");
            ViewBag.DepartmentID = new SelectList(db.Department, "ID", "Type");
            return View(item);
        }

        public async Task<ActionResult> GetCities(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IEnumerable<City> city = await db.City.Where(c => c.RegionID == id).ToListAsync();
            if (city == null)
            {
                return HttpNotFound();
            }
            return Json(city, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetDepartments(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IEnumerable<Department> department = await db.Department.Where(c => c.CityID == id).ToListAsync();
            if (department == null)
            {
                return HttpNotFound();
            }
            return Json(department, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetEmployees(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IEnumerable<Employee> employee = await db.Employee.Where(c => c.DepartmentID == id).ToListAsync();
            if (employee == null)
            {
                return HttpNotFound();
            }
            return Json(employee, JsonRequestBehavior.AllowGet);
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
