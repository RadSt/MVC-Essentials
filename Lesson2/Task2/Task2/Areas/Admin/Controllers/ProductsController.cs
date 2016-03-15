using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task2.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Admin/Products
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Create()
        {
            return View();
        }

        public ViewResult Delete()
        {
            return View();
        }
    }
}