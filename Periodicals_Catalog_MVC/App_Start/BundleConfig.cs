using System.Web;
using System.Web.Optimization;

namespace Periodicals_Catalog_MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-theme.css",
                      "~/Content/elegant-icons-style.css",
                      "~/Content/style.css",
                      "~/Content/style-responsive.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/jsscripts").Include(

               "~/Scripts/jquery.scrollTo.min.js",
               "~/Scripts/jquery.nicescroll.js",
               "~/Scripts/scripts.js",
               "~/Scripts/jquery.slimscroll.min.js"
               ));
        }
    }
}
