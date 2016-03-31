using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Task1.Attributes
{
    public class StartActionAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            WriteMessageToFile(String.Format("Action {0} Time {1}",filterContext.ActionDescriptor.ActionName,DateTime.Now));
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }

        private void WriteMessageToFile(string message)
        {
            string path = HttpContext.Current.Server.MapPath("~/App_Data/log.txt");
            using (StreamWriter file=new StreamWriter(path,true))
            {
                file.WriteLine(message);
            }
        }
    }
}