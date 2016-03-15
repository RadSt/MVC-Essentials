using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task2.Models;

namespace Task2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List <Products> listProd = new List<Products>
            {
               new Products{Id=1,Name = "Bread", Price=200M, Description = "Tasty peace of bread"},
               new Products{Id=2,Name="Milk",Price=150M,Description = "Fresh milk"},
               new Products{Id = 3, Name = "Sugar", Price = 500M, Description = "Indian Sugar"},
               new Products{Id=4, Name = "Fish", Price=100, Description = "Skumbria"},
               new Products{Id=5, Name = "Juice",Price = 150, Description = "Orange"} 
            };
            return View(listProd);
        }
    }
}