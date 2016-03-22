using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task3.Models;

namespace Task3.Controllers
{
    public class UsersController : Controller
    {
        DatabaseContext db=new DatabaseContext();
        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        public ActionResult Details(int userId)
        {
            User user = db.Users.Find(userId);
            if (user==null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}