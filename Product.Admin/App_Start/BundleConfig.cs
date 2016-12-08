using System.Web;
using System.Web.Optimization;

namespace Product.Admin
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/Scripts/scripts/jQuery")
               .Include("~/scripts/jquery-{version}.js")
               .Include("~/scripts/jquery-ui-{version}.js")
               .Include("~/scripts/jquery.validate.js")
               );
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/Content/styles/FileUpload")
             .Include("~/Content/styles/FileUpload/jquery.fileupload-ui.css")
             );

            bundles.Add(new ScriptBundle("~/Scripts/scripts/FileUpload")
            .Include("~/Scripts/scripts/FileUpload/vendor/jquery.ui.widget.js")
            .Include("~/Scripts/scripts/FileUpload/tmpl.js")
            .Include("~/Scripts/scripts/FileUpload/load-image.js")
            .Include("~/Scripts/scripts/FileUpload/canvas-to-blob.js")

            .Include("~/Scripts/scripts/FileUpload/jquery.iframe-transport.js")
            .Include("~/Scripts/scripts/FileUpload/jquery.fileupload.js")
            .Include("~/Scripts/scripts/FileUpload/jquery.fileupload-fp.js")
            .Include("~/Scripts/scripts/FileUpload/jquery.fileupload-ui.js")
            //.Include("~/scripts/FileUpload/locale.js")
            .Include("~/Scripts/scripts/FileUpload/main.js")
            );
        }
    }
}
