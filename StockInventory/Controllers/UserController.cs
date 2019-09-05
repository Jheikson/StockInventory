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
    public class UserController : Controller
    {
        private StockInventoryContext db = new StockInventoryContext();

        // GET: User
        public async Task<ActionResult> Index()
        {
            var user = db.User.Include(u => u.Employee);
            return View(await user.ToListAsync());
        }

        // GET: User/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.User.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            var employees = db.Employee.ToList();
            List<object> selectListEmployees = new List<object>();
            foreach (var employee in employees)
                selectListEmployees.Add(new
                {
                    Id = employee.ID,
                    Name = employee.Cedula + " - " + employee.FirstName + " " + employee.LastName
                });
            ViewBag.EmployeeID = new SelectList(selectListEmployees, "Id", "Name");
            return View();
        }

        // POST: User/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,UserName,Password,ConfirmPassword,EmployeeID")] User user)
        {
            if (ModelState.IsValid)
            {
                user.ID = Guid.NewGuid();
                db.User.Add(user);
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
            return View(user);
        }

        // GET: User/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.User.FindAsync(id);
            if (user == null)
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
            return View(user);
        }

        // POST: User/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,UserName,Password,ConfirmPassword,EmployeeID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
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
            return View(user);
        }

        // GET: User/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.User.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            User user = await db.User.FindAsync(id);
            db.User.Remove(user);
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
