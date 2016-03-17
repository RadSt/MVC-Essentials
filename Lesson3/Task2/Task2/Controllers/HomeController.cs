using System.Collections.Generic;
using System.Web.Mvc;
using Task2.Models;

namespace Task2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private List<Product> products= new List<Product>
        {
            new Product{Id=1,Name = "Bread",Price = 200M,CreatedDate = "03.17.2016"},
            new Product{Id=2,Name="Meat",Price = 300M,CreatedDate = "10.06.2016"},
            new Product{Id=3,Name = "Fish",Price = 500M,CreatedDate = "11.05.16"},
            new Product{Id=4,Name="Cheese",Price = 100M,CreatedDate = "12.08.16"},
            new Product{Id=5,Name="Apple",Price = 50M,CreatedDate = "11.03.16"}
        };

        public ViewResult Index()
        {
            return View(products);
        }

        [ChildActionOnly]
        public ActionResult ProductsList(Product product)
        {
            return PartialView("_ProductsList", product);
        }
        [ChildActionOnly]
        public ActionResult ProductsTable(Product product)
        {
            return PartialView("_ProductsTable", product);
        }
    }
}