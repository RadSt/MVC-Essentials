using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Task3.ModelBinders;
using Task3.Models;

namespace Task3
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(User), new MyModelBinder());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
