using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task3.Models;

namespace Task3.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginPage(User user)
        {
            Debug.WriteLine("prop1 " + user.Name);
            Debug.WriteLine("prop2 " + user.Password);
            return View();
        }


    }
}