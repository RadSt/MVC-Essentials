using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task1.Models;

namespace Task1.Controllers
{
    public class ProductsController : Controller
    {

        // GET: Products
        public ActionResult ShowProducts()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ShowProducts(int? prodId)
        {
            return View("ShowProducts", (object)prodId);
        }

        public ActionResult ProductsData(int? prodId)
        {
            var selectedProducts = ProductsDataBase.Products;
            if (prodId != null)
            {
                selectedProducts = selectedProducts.
                Where(p => p.Id > prodId).
                Take(5).ToArray();
            }
            return PartialView(selectedProducts);
        }
    }
}