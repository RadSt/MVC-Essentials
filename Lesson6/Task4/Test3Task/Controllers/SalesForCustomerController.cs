using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test3Task.Models;

namespace Test3Task.Controllers
{
    public class SalesForCustomerController : Controller
    {
        DatabaseContext db=new DatabaseContext();
        // GET: SalesForCustomer
        public ActionResult SalesForCustomerReportShow()
        {
            var orders = db.Orders.Include(o => o.Customer).Include(o => o.Product);
            ViewBag.Customers = new SelectList(db.Customers, "CustomerId", "Name");
            return View(orders.ToList());
        }
    }
}