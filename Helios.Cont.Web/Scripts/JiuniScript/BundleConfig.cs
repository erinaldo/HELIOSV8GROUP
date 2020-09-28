using System.Web;
using System.Web.Optimization;

namespace Helios.Cont.Presentation.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
          

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));


            //"~/Scripts/JiuniScript/jquery-1.10.2.js",
            //"~/Scripts/JiuniScript/jquery-1.10.2.js"
         
   bundles.Add(new ScriptBundle("~/bundles/sps").Include(
                "~/Scripts/JiuniScript/jquery-1.10.2.js",
                  "~/Scripts/JiuniScript/jquery-ui.js",
                   "~/Scripts/JiuniScript/jquery-ui-1.10.4.custom.min.js",
                   "~/Scripts/JiuniScript/myScripts.js",
                   "~/Scripts/JiuniScript/ScriptOrders.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/JiuniBundle/jquery-ui.css",
                      "~/Content/site.css"));
                       

            bundles.Add(new StyleBundle("~/Content/JiuniBundle").Include(
                "~/Content/JiuniBundle/jquery-ui-1.10.4.custom.min.css"));

           

        }
    }
}
