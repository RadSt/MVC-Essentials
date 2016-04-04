using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test3Task.Controllers
{
    public class AccountController : Controller
    {
        [Authorize]
        [InitializeSimpleMembershipAttribute]
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
    }
}