using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Calculate(int firstField, int secField, string clcBtn)
        {
            int result = 0;
            
            try
            {
                switch (clcBtn)
                {
                    case "+":
                        result = firstField + secField;
                        break;
                    case "-":
                        result = firstField - secField;
                        break;
                    case "*":
                        result = firstField*secField;
                        break;
                    case "/":
                        result = firstField/secField;
                        break;
                }
            }
            catch (Exception e)
            {
                ViewBag.Result = e.ToString();
            }

            ViewBag.Result = result;
            return View("Index");
        }
    }
}