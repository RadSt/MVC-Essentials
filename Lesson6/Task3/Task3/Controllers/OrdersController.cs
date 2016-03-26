using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task3.Models;

namespace Task3.Controllers
{
    public class OrdersController : Controller
    {
        DatabaseContext db=new DatabaseContext();
        // GET: Orders
        public ActionResult Index()
        {
            return View(db.Order.ToList());
        }
    }
}