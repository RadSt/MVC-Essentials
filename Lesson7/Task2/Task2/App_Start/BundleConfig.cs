using System.Web.Optimization;

namespace Test3Task
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/medornizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/jqvalidate")
                .Include("~/Scripts/jquery.unobtrusive*", 
                "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap.js"));
            bundles.Add(new StyleBundle("~/content/css")
                .Include("~/Content/site.css","~/Content/bootstrap.css"));
        }
    }
}