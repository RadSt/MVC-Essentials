using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task2.Models;

namespace Task2.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ProductsList()
        {
            Product[] products=new Product[]
            {
                new Product{Id=1,Name = "Bread",Description = "Fresh",Price = 200M},
                new Product{Id=2,Name ="Fish",Description = "Sea",Price=500M},
                new Product{Id=3,Name = "Oranges",Description = "Dairy",Price = 300M},
                new Product{Id=4,Name ="Apples",Description = "Fruits",Price = 600M},
                new Product{Id=5,Name = "Cake",Description = "With Cream",Price = 50M} 
            };
            return View(products);
        }
    }
}