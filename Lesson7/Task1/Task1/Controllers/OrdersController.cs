﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task1.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult AddOrder()
        {
            return View();
        }
    }
}