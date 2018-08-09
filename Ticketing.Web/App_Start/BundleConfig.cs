using System.Web;
using System.Web.Optimization;

namespace Ticketing
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/ticket").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-ui-{version}.js",
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*",
                "~/Scripts/summernote/summernote.js"));

            

            bundles.Add(new ScriptBundle("~/bundles/chosen").Include("~/Scripts/chosen.jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/bootstrap-switch.js"));

            bundles.Add(new ScriptBundle("~/bundles/jsTree3").Include("~/Scripts/jsTree3/jstree.js"));
            //Custom Scripts
            bundles.Add(new ScriptBundle("~/bundles/Custom").IncludeDirectory(
                "~/Scripts/Custom", "*.js", true));

            bundles.Add(new StyleBundle("~/Content/chosen").Include("~/Content/bootstrap-chosen.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/bootstrap-switch/bootstrap-switch.css",
                      "~/Content/chosen.min.css",
                      "~/Content/summernote/summernote.css"));
            bundles.Add(new StyleBundle("~/Content/jsTree3").Include(
                     "~/Content/jsTree/themes/default/style.css"));
        }
    }
}
