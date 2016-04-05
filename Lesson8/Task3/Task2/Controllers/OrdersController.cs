using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Web.Mvc;
using Test3Task.Models;

namespace Test3Task.Controllers
{
    public class OrdersController : Controller
    {
        DatabaseContext db=new DatabaseContext();
        // GET: Orders
        [Authorize]
        public ActionResult OrdersList()
        {
            var orders = db.Orders.Include(o => o.Product).Include(o => o.Customer);
            return View(orders.ToList());
        }
        [Authorize]
        public ActionResult Details(int orderId = 0)
        {
            var orders = db.Orders.Include(o => o.Product).Include(o => o.Customer);
            Order order = orders
                .FirstOrDefault(o => o.OrderId == orderId);
            return View(order);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
            ViewBag.CustomerId = new SelectList(db.Customers,"CustomerId","Name");
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("OrdersList");
            }
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int orderId = 0)
        {
            Order order = db.Orders.Find(orderId);
            ViewBag.ProductId=new SelectList(db.Products,"ProductId","Name");
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name");
            return View(order);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("OrdersList");
            }
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int orderId=0)
        {
            var orders = db.Orders.Include(o => o.Product).Include(o => o.Customer);
            Order order = orders
                .FirstOrDefault(o => o.OrderId == orderId);
            return View(order);
        }
        [HttpPost,ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteOrder(int orderId)
        {
            Order order = db.Orders.Find(orderId);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("OrdersList");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}