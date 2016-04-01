using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test3Task.Filters;

namespace Test3Task.Controllers
{
    public class AccountController : Controller
    {
        [Authorize]
        [InitializeSimpleMembership]
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
    }
}