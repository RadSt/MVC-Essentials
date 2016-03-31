using System.Web.Mvc;
using Task3.Models;
using IModelBinder = System.Web.ModelBinding.IModelBinder;

namespace Task3.ModelBinders
{
    public class MyModelBinder:IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            User user = (User) bindingContext.Model ?? new User();

            bool hasPrefix = bindingContext.ValueProvider.ContainsPrefix(bindingContext.ModelName);
        }
    }
}