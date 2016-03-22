using System.Diagnostics;
using System.Web.Mvc;
using Task1.Models;

namespace Task1.Controllers
{
    public class HomeController : Controller
    {
        User users = new User();
        // GET: Home
        public ActionResult Index()
        {
            return View(users);
        }

        [HttpPost]
        public ActionResult Index(int id, string name, string password)
        {
            Debug.WriteLine(id);
            Debug.WriteLine(name);
            Debug.WriteLine(password);
            return View(users);
        }
    }
}