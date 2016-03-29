using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task1.Models;

namespace Task1.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult AddOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                return View("Succes");
            }
            return View();
        }
    }
}