using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test3Task.Models;

namespace Test3Task.Controllers
{
    public class CustomersController : Controller
    {
        DatabaseContext db=new DatabaseContext();
        // GET: Costomers
        public ActionResult CustomersList()
        {
            return View(db.Customers);
        }

        public ActionResult Details(int customerId = 0)
        {
            Customer customer = db.Customers.Find(customerId);
            return View(customer);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}