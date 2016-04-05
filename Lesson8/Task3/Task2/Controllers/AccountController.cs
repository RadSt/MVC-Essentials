using System;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Web.WebPages.OAuth;
using MvcInternetApplication.Filters;
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

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            // WebSecurity.Login - аутентифицирует пользователя.
            // Если логин и пароль введены правильно - метод возвращает значение true после чего выполняет добавление специальных значений в cookies.
            if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, model.RememberMe))
            {
                return RedirectToLocal(returnUrl);
            }

            // Был введен не правильный логин или пароль
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            //Удаление специальных аунтефикационных cookie значений
            WebSecurity.Logout();

            return RedirectToAction("OrdersList", "Orders");
        }
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                //Попытка создания пользователя
                try
                {
                    //Создание пользователя
                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password);
                    //Аутентификация пользователя
                    WebSecurity.Login(model.UserName,model.Password);
                    return RedirectToAction("OrdersList", "Orders");
                }
                catch (MembershipCreateUserException ex)
                {
                    
                    ModelState.AddModelError("",ErrorCodeToString(ex.StatusCode));
                }
            }
            return View(model);
        }

        public ActionResult Manage(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess
                    ? "Ваш пароль был изменен."
                    : message == ManageMessageId.SetPasswordSuccess
                        ? "Ваш пароль установлен"
                        : message == ManageMessageId.RemoveLoginSuccess
                            ? "Ваш логин удален"
                            : "";
            ViewBag.HasLocalPassword = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(LocalPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                //ChangePasssword выбрасывает исключения в случае неудачной смены пароля
                bool changePasswordSucceded;
                try
                {
                    changePasswordSucceded = WebSecurity.ChangePassword(User.Identity.Name, model.OldPassword,
                        model.NewPassword);
                }
                catch (Exception)
                {

                    changePasswordSucceded = false;
                }

                if (changePasswordSucceded)
                {
                    return RedirectToAction("Manage", new {Message = ManageMessageId.ChangePasswordSuccess});
                }
                else
                {
                    ModelState.AddModelError("","Вы ввели неправильный текущий или новый пароль");
                }
                // Если ничего не получилось
            }
            return View(model);
        }
        #region Helpers

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("OrdersList", "Orders");
        }

        private string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";   
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess
        }

        #endregion
    }
}