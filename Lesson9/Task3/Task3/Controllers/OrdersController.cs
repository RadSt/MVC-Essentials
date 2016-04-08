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
        IEnumerable<Order> order = OrdersDatabase.Orders;
        // GET: Default
        public ActionResult ShowOrders()
        {
            return View(order);
        }

        public ActionResult OrdersData(string id)
        {
            order = order.Where(o => o.Customer == id);
            return PartialView(order);
        }
    }
}