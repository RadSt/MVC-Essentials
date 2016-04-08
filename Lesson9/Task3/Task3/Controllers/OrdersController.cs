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
        IEnumerable<Order> orders = new List<Order>();
        // GET: Default
        public ActionResult ShowOrders()
        {
            orders = OrdersDatabase.Orders;
            string[] customersList = orders.Select(o=>o.Customer).Distinct().ToArray();
            return View(customersList);
        }

        public ActionResult OrdersData(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                orders = OrdersDatabase.Orders;
                orders = orders.Where(o => o.Customer == id);
            }
            return PartialView(orders);
        }
    }
}