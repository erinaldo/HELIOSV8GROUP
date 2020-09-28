using System.Web;
using System.Web.Optimization;

namespace Helios.SalesGeneral.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery")
             .Include("~/assets/libs/jquery/dist/jquery.min.js")
             .Include("~/assets/libs/bootstrap/dist/js/bootstrap.min.js")
             .Include("~/assets/libs/perfect-scrollbar/dist/perfect-scrollbar.jquery.min.js")
             .Include("~/assets/extra-libs/sparkline/sparkline.js")
             .Include("~/dist/js/waves.js")
             .Include("~/dist/js/sidebarmenu.js")
             .Include("~/dist/js/custom.min.js")
             .Include("~/assets/libs/flot/excanvas.js")
             .Include("~/assets/libs/flot/jquery.flot.js")
             .Include("~/assets/libs/flot/jquery.flot.pie.js")
             .Include("~/assets/libs/flot/jquery.flot.time.js")
             .Include("~/assets/libs/flot/jquery.flot.stack.js")
             .Include("~/assets/libs/flot/jquery.flot.crosshair.js")
             .Include("~/assets/libs/flot.tooltip/js/jquery.flot.tooltip.min.js")
             .Include("~/dist/js/pages/chart/chart-page-init.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/assets/libs/flot/css/float-chart.css")
                .Include("~/dist/css/style.min.css"));

            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
        }
    }
}
