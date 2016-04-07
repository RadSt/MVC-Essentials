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

        ProductsArray productsArray=new ProductsArray();
        // GET: Products
        public ActionResult ShowProducts()
        {
            Product[] products=productsArray.CreateProductsArray();
            return View(products);
        }
    }
}