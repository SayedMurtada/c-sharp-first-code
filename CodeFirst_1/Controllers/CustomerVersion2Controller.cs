using CodeFirst_1.Models;
using CodeFirst_1.Repository;//
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst_1.Controllers
{
    public class CustomerVersion2Controller : Controller
    {
        private readonly ICustomer customer;

        public CustomerVersion2Controller(ICustomer customer)
        {
            this.customer = customer;
        }
        public IActionResult Index()
        {
            return View(customer.GellAllCustomers());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer c)
        {
            if (ModelState.IsValid)
            {
                customer.Add(c);
                return RedirectToAction("Index");
            }
            return View(c);

        }
    }
}
