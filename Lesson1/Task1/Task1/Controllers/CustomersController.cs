﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task1.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customer
        public ActionResult Add()
        {
            ViewBag.message = "hello from CustomersController Add";
            return View();
        }
    }
}