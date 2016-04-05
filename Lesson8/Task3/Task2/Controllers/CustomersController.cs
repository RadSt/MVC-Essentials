using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test3Task.Models;

namespace Test3Task.Controllers
{
    public class CustomersController : Controller
    {
        DatabaseContext db=new DatabaseContext();
        // GET: Customers
        [Authorize]
        public ActionResult CustomersList()
        {
            return View(db.Customers);
        }
        [Authorize]
        public ActionResult Details(int customerId = 0)
        {
            Customer customer = db.Customers.Find(customerId);
            return View(customer);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("CustomersList");
            }
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int customerId = 0)
        {
            Customer customer = db.Customers.Find(customerId);
            return View(customer);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CustomersList");
    
            }
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int customerId)
        {
            Customer customer = db.Customers.Find(customerId);
            return View(customer);
        }
        [HttpPost,ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteCustomer(int customerId)
        {
            Customer customer = db.Customers.Find(customerId);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("CustomersList");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        } 
    }
}