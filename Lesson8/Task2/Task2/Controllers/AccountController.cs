using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Test3Task.Filters;
using Test3Task.Models;
using WebMatrix.WebData;

namespace Test3Task.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class AccountController : Controller
    {

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie:model.RememberMe))
            {
                return RedirectToAction(returnUrl);
            }
            ModelState.AddModelError("","Введенный пароль или пользователь не существуют");
            return View(model);
        }
    }
}