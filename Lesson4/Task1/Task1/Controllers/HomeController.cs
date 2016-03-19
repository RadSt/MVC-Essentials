using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IdQuery(string id = null)
        {
            string contentType = "plain/text";
            string path = Server.MapPath("/Content/FileId.txt");

            if (id == null)
            {
                ViewBag.Message = "Данные не предоставлены";
                return View("Index");
            }

            using (StreamWriter sWriter = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sWriter.WriteLine(id);
            }

            byte[] data = System.IO.File.ReadAllBytes(path);

            return File(data, contentType);
        }
    }
}