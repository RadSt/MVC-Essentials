using _002_SimpleAjaxApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _002_SimpleAjaxApplication.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            OrderFilterOptions orderFilter = new OrderFilterOptions();
            return View(orderFilter);
        }

        [HttpPost]
        public ActionResult Index(OrderFilterOptions orderFilterOpt)
        {
            OrderFilterOptions orderFilter = new OrderFilterOptions()
            {
                CustomerName = orderFilterOpt.CustomerName,
                ProductName = orderFilterOpt.ProductName,
                ProductQuant = orderFilterOpt.ProductQuant
            };
            // id - имя клиента, заказы которого необходимо выводить на странице.
            return View("Index", orderFilter);
        }

        public ActionResult OrdersData(OrderFilterOptions orderFilterOpt)
        {
            var data = OrdersDatabase.Orders;
            if (!string.IsNullOrEmpty(orderFilterOpt.CustomerName) && orderFilterOpt.CustomerName != "All")
            {
                // выполняем выборку по свойству Customer если значение id не пустое и не равное "All"
                data = data.Where(e => e.Customer == orderFilterOpt.CustomerName);
            }
            if (!string.IsNullOrEmpty(orderFilterOpt.ProductName) && orderFilterOpt.ProductName != "All")
            {
                data = data.Where(d => d.Product == orderFilterOpt.ProductName);
            }
            if (!string.IsNullOrEmpty(orderFilterOpt.ProductQuant) && orderFilterOpt.ProductQuant != "All")
            {
                int quant;
                if (int.TryParse(orderFilterOpt.ProductQuant, out quant))
                {
                    data = data.Where(d => d.Quantity == quant);
                }
                
            }
            return PartialView(data);
        }

    }
}
