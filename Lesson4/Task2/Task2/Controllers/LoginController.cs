using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult AuthorizateUser(string txtLogin, string txtPassword)
        {
            string path = Server.MapPath("~/Content/Login.txt");
            using (StreamWriter stWriter=new StreamWriter(path,false,System.Text.Encoding.Default))
            {
                stWriter.WriteLine("Login {0} Password {1}",txtLogin,txtPassword);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}