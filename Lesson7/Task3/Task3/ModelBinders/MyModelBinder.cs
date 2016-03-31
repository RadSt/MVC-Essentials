using System.Web.ModelBinding;
using System.Web.Mvc;
using Task3.Models;
using IModelBinder = System.Web.Mvc.IModelBinder;
using ModelBindingContext = System.Web.Mvc.ModelBindingContext;
using ValueProviderResult = System.Web.Mvc.ValueProviderResult;

namespace Task3.ModelBinders
{
    public class MyModelBinder:IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            User user = (User) bindingContext.Model ?? new User();
            user.Name = GetValue(bindingContext, "Name");
            user.Password = GetValue(bindingContext, "Password");

            return user;
        }

        private string GetValue( ModelBindingContext bindingContext, string key)
        {
            ValueProviderResult vpr = bindingContext.ValueProvider.GetValue(key);
            return vpr == null ? null : vpr.AttemptedValue;
        }
    }
}