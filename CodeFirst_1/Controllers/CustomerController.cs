using CodeFirst_1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst_1.Controllers
{
    public class CustomerController : Controller
    {
        private readonly SADBContext db;

        public CustomerController(SADBContext db)
        {
            this.db = db;
        }


        public IActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Customer cust)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(cust);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cust);
        }
         [HttpGet]
        public IActionResult Details(int id)
        {
            //var cust = db.Customers.Where(a=>a.Id==id).FirstOrDefault();
            var cust = db.Customers.Find(id);
            return View(cust);
        }
        [HttpGet]
         public IActionResult Edit(int id)
        {
            var cust = db.Customers.Find(id);
            return View(cust);

        }
        [HttpPost]
        public IActionResult Edit(Customer cust)
        {
          
            if (ModelState.IsValid)
            {
                /*
                var customer = db.Customers.Find(cust.Id);
                customer.Name = cust.Name;
                customer.Address = cust.Address;
                customer.Phone = cust.Phone;
                */
                var customer = db.Customers.Attach(cust);
                customer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cust);

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var cust = db.Customers.Find(id);
            return View(cust);
        }

        [HttpPost]
        public IActionResult Delete(Customer cust)
        {
            if (ModelState.IsValid)
            {
                var customer = db.Customers.Find(cust.Id);
                db.Customers.Remove(customer);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(cust);

        }
    }
}
