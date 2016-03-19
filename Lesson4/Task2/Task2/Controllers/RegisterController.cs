using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task2.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(string txtLogin, string txtPassword, string txtPassConfirm, string txtEmail)
        {
            string path = Server.MapPath("~/Content/Register.txt");
            using (StreamWriter stWriter=new StreamWriter(path,false,System.Text.Encoding.Default))
            {
                stWriter.WriteLine("Login {0} Password {1} Password Confirm {2} Email {3}",
                    txtLogin,txtPassword,txtPassConfirm,txtEmail);
            }

            return RedirectToAction("Index","Home");
        }
    }
}