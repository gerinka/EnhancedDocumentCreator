using System.Web;
using System.Web.Optimization;

namespace MasterThesisCreator
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/bower_components/jquery/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/bower_components/jquery.validate/dist/jquery.validate.js",
                        "~/bower_components/jquery.validate/dist/additional-methods.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/bower_components/bootstrap/bootstrap/dist/js.js",
                      "~/bower_components/respond/dest/respond.src.js",
                      "~/bower_components/bootstrap-wysihtml5/dist/bootstrap-wysihtml5-0.0.2.js",
                      "~/bower_components/bootstrap-select/dist/js/bootstrap-select.js",
                      "~/bower_components/tags/dist/tags.js",
                      "~/bower_components/twitter-bootstrap-wizard/jquery.bootstrap.wizard.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-datepicker").Include(
        "~/bower_components/moment/moment.js",
        "~/bower_components/moment/locale/bg.js",
        "~/bower_components/eonasdan-bootstrap-datetimepicker/src/js/bootstrap-datetimepicker.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/bower_components/bootstrap/dist/css/bootstrap.css", 
                      "~/bower_components/eonasdan-bootstrap-datetimepicker/src/_bootstrap-datetimepicker.less",
                      "~/bower_components/bootstrap-wysihtml5/dist/bootstrap-wysihtml5-0.0.2.css",
                      "~/bower_components/bootstrap-select/dist/css/bootstrap-select.css",
                      "~/Content/site.css",
                      "~/Content/Common/*.css"));
            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}
