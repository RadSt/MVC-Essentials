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
        public ActionResult Index()
        {
            return View(db.Products);
        }

        public ActionResult Details(int productId=0)
        {
            Product product = db.Products.Find(productId);
            return View(product);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int productId=0)
        {
            Product product = db.Products.Find(productId);
            return View(product);
        }
        
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int productId=0)
        {
            Product product = db.Products.Find(productId);
            return View(product);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteProduct(int productId=0)
        {
            Product product = db.Products.Find(productId);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}