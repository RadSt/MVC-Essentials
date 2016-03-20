using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task2.Models;

namespace Task2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            LoginModel loginController = new LoginModel();
            return View(loginController);
        }

        public ActionResult AuthorizateUser(LoginModel loginModel)
        {
            string path = Server.MapPath("~/Content/Login.txt");
            using (StreamWriter stWriter=new StreamWriter(path,false,System.Text.Encoding.Default))
            {
                stWriter.WriteLine("Login {0} Password {1}",loginModel.Login,loginModel.Password);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}