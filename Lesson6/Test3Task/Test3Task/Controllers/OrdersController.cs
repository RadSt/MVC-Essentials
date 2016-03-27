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

        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
            ViewBag.CustomerId = new SelectList(db.Customers,"CustomerId","Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return RedirectToAction("OrdersList");
        }

        public ActionResult Edit(int orderId = 0)
        {
            Order order = db.Orders.Find(orderId);
            ViewBag.ProductId=new SelectList(db.Products,"ProductId","Name");
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name");
            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(Order order)
        {
            db.Entry(order).State=EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("OrdersList");
        }

        public ActionResult Delete(int orderId=0)
        {
            Order order = db.Orders.Find(orderId);
            return View(order);
        }

        [HttpPost,ActionName("Delete")]
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