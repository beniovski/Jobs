using System.Web;
using System.Web.Optimization;

namespace JobsPortal
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

            // Użyj wersji deweloperskiej biblioteki Modernizr do nauki i opracowywania rozwiązań. Następnie, kiedy wszystko będzie
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/homeIndex").Include(
                     "~/Scripts/gator.min.js",
                     "~/Scripts/parallaxbg.js",
                     "~/Scripts/jquery-ui-1.12.1.js"));

               bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",                                      
                      "~/Content/custom.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/icofont.css",
                      "~/Content/main.css",
                      "~/Content/modern-business.css",                     
                      "~/Content/parallax.css",
                      "~/Content/responsive.css",
                      "~/Content/themes/base/base.css",
                      "~/Content/themes/base/jquery-ui.css",
                      "~/Content/slidr.css"));
        }
    }
}
