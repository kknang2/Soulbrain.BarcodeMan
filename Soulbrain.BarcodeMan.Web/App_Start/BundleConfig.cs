using System.Web;
using System.Web.Optimization;

namespace Soulbrain.BarcodeMan.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // javascript
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js").Include(
                        "~/Scripts/jquery-ui-i18n.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                        "~/Scripts/angular.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/Scripts/datejs.js").Include(
                        "~/assets/js/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/print").Include(
                        "~/assets/js/JsBarcode/JsBarcode.all.min.js").Include(
                        "~/assets/js/print.js"));

            bundles.Add(new ScriptBundle("~/bundles/barcode").Include(
                        "~/assets/js/Controllers/BarcodePrint.js").Include(
                        "~/assets/js/Controllers/PopupProduct.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            // css
            bundles.Add(new StyleBundle("~/Content/themes/base/jqueryui").Include(
                      "~/Content/themes/base/all.css"));

            bundles.Add(new StyleBundle("~/assets/css/style").Include(
                      "~/assets/css/webfont.css",
                      "~/assets/css/reset.css",
                      "~/assets/css/modal.css",
                      "~/assets/css/default.css",
                      "~/assets/css/custom.css"));
        }
    }
}
