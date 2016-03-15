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
        public ActionResult Result(int x,int y)
        {
            int result = 0;

            if (x == 10 && y == 20)
            {
                result = 10 + 20;
            }
            else if (x==5 && y==5)
            {
                result = 5*5;
            }
            else if (x==10 && y==3)
            {
                result = 10 - 3;
            } 
            else if (ValidateRequest)
            {
                result = 10/2;
            }


            return View(result);
        }
    }
}