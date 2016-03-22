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
            PhoneNum phoneNum =new PhoneNum(){CountryCode = "(123)",CityCode = "(456)",PhoneNumber = "(7891011)"};
            return View(phoneNum);
        }
    }
}