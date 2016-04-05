using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test3Task.Models;

namespace Test3Task.Controllers
{
    public class ProductsController : Controller
    {
        DatabaseContext db=new DatabaseContext();
        // GET: Products
        [Authorize]
        public ActionResult ProductsList()
        {
            return View(db.Products);
        }
        [Authorize]
        public ActionResult Details(int productId=0)
        {
            Product product = db.Products.Find(productId);
            return View(product);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("ProductsList");
            }
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int productId=0)
        {
            Product product = db.Products.Find(productId);
            return View(product);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ProductsList");
   
            }
            return View();
        }
        [Authorize(Roles="Admin")]
        public ActionResult Delete(int productId=0)
        {
            Product product = db.Products.Find(productId);
            return View(product);
        }

        [HttpPost,ActionName("Delete")]
        [Authorize(Roles="Admin")]
        public ActionResult DeleteProduct(int productId=0)
        {
            Product product = db.Products.Find(productId);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("ProductsList");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}