using employeedepartment.Data;
using employeedepartment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employeedepartment.Controllers
{
    public class EmployeeController : Controller
    {
        private AppDbContext db;
        public EmployeeController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult AllEmployee()
        {
            var data = db.employees.Include(x=>x.department);
            return View(data);
        }
        public IActionResult Details(int id)
        {
            var data = db.employees.Find(id);
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.name = new SelectList(db.departments.ToList(), "departmentId", "departmentName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(employee employee)
        {
            db.employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("AllEmployee");
        }
        public IActionResult Edit(int id)
        {
            ViewBag.name = new SelectList(db.departments.ToList(), "departmentId", "departmentName");
            var data = db.employees.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(employee employee)
        {
            db.employees.Update(employee);
            db.SaveChanges();
            return RedirectToAction("AllEmployee");
        }
        [HttpGet]
        public IActionResult delete(int id)
        {
            var data = db.employees.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult delete(int id,employee employee)
        {
            var data = db.employees.Find(id);
            db.employees.Remove(data);
            db.SaveChanges();
            return RedirectToAction("AllEmployee");
        }

    }
}
