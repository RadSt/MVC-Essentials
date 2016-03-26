using System.Data.Entity;
using System.Linq;
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
            var orders = db.Orders.Include(o => o.Product).Include(o => o.Customer);
            return View(orders.ToList());
        }

        public ActionResult Details(int orderId = 0)
        {
            Order order=db.Orders.Find(orderId);
            return View(order);
        }
    }
}