using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test3Task.Models;

namespace Test3Task.Controllers
{
    public class SalesForPeriodController : Controller
    {
        DatabaseContext db=new DatabaseContext();
        // GET: SalesForPeriod
        [Authorize]
        public ActionResult SalesForPeriodReportShow()
        {
            ViewBag.BeginDate = DateTime.Today.AddDays(-1);
            ViewBag.EndDate = DateTime.Today;
            var orders = db.Orders.Include(m => m.Customer).Include(m => m.Product);
            return View(orders.ToList());
        }
        [HttpPost]
        [Authorize]
        public ActionResult SalesForPeriodReportShow(DateTime beginDate, DateTime endDate)
        {
            var orders = db.Orders.Include(m => m.Customer).Include(m => m.Product);
            var orderForReport = orders
                .Where(o => o.Date >= beginDate && o.Date <= endDate);
            return View(orderForReport.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}