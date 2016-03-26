using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test3Task.Models;

namespace Test3Task.Controllers
{
    public class OrdersController : Controller
    {
        DatabaseContext db=new DatabaseContext();
        // GET: Orders
        public ActionResult OrdersList()
        {
            return View(db.Orders);
        }
    }
}