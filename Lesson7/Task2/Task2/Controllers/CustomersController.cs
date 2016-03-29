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

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return RedirectToAction("CustomersList");
        }

        public ActionResult Edit(int customerId = 0)
        {
            Customer customer = db.Customers.Find(customerId);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            db.Entry(customer).State=EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("CustomersList");
        }

        public ActionResult Delete(int customerId)
        {
            Customer customer = db.Customers.Find(customerId);
            return View(customer);
        }

        [HttpPost,ActionName("Delete")]
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