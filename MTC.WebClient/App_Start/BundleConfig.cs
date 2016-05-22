using System.Web;
using System.Web.Optimization;

namespace Mtc.WebClient
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/bower_components/bootstrap/dist/js/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/bower_components/twitter-bootstrap-wizard/jquery.bootstrap.wizard.js",
                      "~/bower_components/moment/moment.js",
                      "~/bower_components/moment/locale/bg.js",
                      "~/bower_components/eonasdan-bootstrap-datetimepicker/build/js/bootstrap-datetimepicker.min.js",
                      "~/bower_components/bootstrap-select/dist/js/bootstrap-select.min.js",
                      "~/bower_components/bootstrap-select/dist/js/i18n/defaults-bg_BG.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/topicCreator").Include(
                     "~/Scripts/ApplicationScripts/*.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/bower_components/bootstrap/dist/css/bootstrap.css",
                      "~/Content/site.css",
                      "~/bower_components/bootstrap/dist/css/bootstrap-theme.css",
                      "~/bower_components/eonasdan-bootstrap-datetimepicker/build/css/bootstrap-datetimepicker.css",
                      "~/bower_components/bootstrap-select/dist/css/bootstrap-select.min.css",
                      "~/bower_components/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css"));
        }
    }
}
