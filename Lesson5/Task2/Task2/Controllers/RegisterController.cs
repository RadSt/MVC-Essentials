using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task2.Models;

namespace Task2.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Register()
        {
            RegistrationModel registrationModel=new RegistrationModel();
            return View(registrationModel);
        }

        [HttpPost]
        public ActionResult CreateUser(RegistrationModel registrationModel)
        {
            string path = Server.MapPath("~/Content/Register.txt");
            using (StreamWriter stWriter=new StreamWriter(path,false,System.Text.Encoding.Default))
            {
                stWriter.WriteLine("Login {0} Password {1} Password Confirm {2} Email {3}",
                    registrationModel.Login,registrationModel.Password,registrationModel.PasswordConfirm,registrationModel.Email);
            }

            return RedirectToAction("Index","Home");
        }
    }
}