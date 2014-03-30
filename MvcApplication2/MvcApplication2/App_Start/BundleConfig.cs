using System.Web;
using System.Web.Optimization;

namespace MvcApplication2
{
    public class BundleConfig
    {
        /*
         Instruction: add all js and css files in bundles
         */
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        //"~/Scripts/jquery-{version}.js",
                        //"~/Scripts/bootstrap.js",
                        //"~/Scripts/bootstrap.min.js",
                        "~/Content/themes/js/jquery.js",
                        "~/Content/themes/js/bootstrap.min.js",
                        "~/Content/themes/js/google-code-prettify/prettify.js",
                        "~/Content/themes/js/bootshop.js",
                        "~/Content/themes/js/jquery.lightbox-0.5.js",
                        "~/Content/themes/switch/theamswitcher.js"));

            

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                //"~/Content/bootstrap.min.css",
                "~/Content/bootstrap.css",
                "~/Content/themes/bootshop/bootstrap.min.css",
                "~/Content/themes/css/base.css",
                 "~/Content/themes/css/bootstrap-responsive.min.css",
                "~/Content/themes/css/font-awesome.css",
                "~/Content/themes/js/google-code-prettify/prettify.css",
                "~/Content/themes/switch/themeswitch.css"));
        }
    }
}