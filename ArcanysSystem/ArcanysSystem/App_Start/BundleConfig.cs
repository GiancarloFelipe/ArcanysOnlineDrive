using System.Web;
using System.Web.Optimization;

namespace ArcanysSystem
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Set the script bundle for jquery scripts...
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/application-script.js",
                    "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr-*"));

            // Set the script bundle for bootstrap scripts...
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(                    
                    "~/Scripts/bootstrap.js"));

            // Set the style bundle for all css...
            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/font-awesome.css",
                    "~/Content/bootstrap.css",
                    "~/Content/Bootstraps/bootstrap-awesome-login.css",
                    "~/Content/Bootstraps/bootstrap-awesome-admin.css",
                    "~/Content/Bootstraps/bootstrap-awesome-site.css"));

            // Set the script bundle for jqueryui scripts...
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                    "~/Scripts/jquery-ui-{version}.js"));

            // Set the style bundle for bootstrap css...
            bundles.Add(new StyleBundle("~/Content/jqueryui").Include(
                    "~/Content/themes/base/jquery-ui.min.css"));

            // Set the script bundle for angularjs scripts...
            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                    "~/Scripts/angular.js",
                    "~/Scripts/AngularJs/app-module.js",
                    "~/Scripts/AngularJs/app-controller.js",
                    "~/Scripts/AngularJs/index-controller.js"));

            // Set the script bundle for dragndrop scripts...
            bundles.Add(new ScriptBundle("~/bundles/dragndropscripts").Include(
                "~/Scripts/DragNDrop/dragndrop.js"));

            // Set the style bundle for dragndrop css...
            bundles.Add(new StyleBundle("~/Content/dragndropcss").Include(
                "~/Scripts/DragNDrop/dragndrop.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
