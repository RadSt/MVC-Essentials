using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task1.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult List()
        {
            ViewBag.message = "hello from ProductsController List";
            return View(ViewBag);
        }

        public ActionResult Details()
        {
            ViewBag.message = "hello from ProductsController Details";
            return View("List",ViewBag);
        }
    }
}