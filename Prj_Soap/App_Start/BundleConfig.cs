using System.Web;
using System.Web.Optimization;

namespace Prj_Soap
{
    public class BundleConfig
    {
        // 如需統合的詳細資訊，請瀏覽 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/process-dialog").Include(
                 "~/Scripts/process-dialog.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin/lib").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-ui-{version}.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js",
                "~/Scripts/AdminJS/fastclick.min.js",
                "~/Scripts/AdminJS/app.min.js",
                "~/Scripts/AdminJS/jquery.sparkline.min.js",
                "~/Scripts/AdminJS/jquery-jvectormap-1.2.2.min.js",
                "~/Scripts/AdminJS/jquery-jvectormap-world-mill-en.js",
                "~/Scripts/AdminJS/jquery.slimscroll.min.js",
                "~/Scripts/Chart.js",
                "~/Scripts/AdminJS/dashboard2.js",
                "~/Scripts/AdminJS/demo.js"
            ));


            bundles.Add(new ScriptBundle("~/bundles/admin/login").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/AdminLogin/animsition.js",
                "~/Scripts/AdminLogin/popper.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/AdminLogin/select2.js",
                "~/Scripts/AdminLogin/moment.js",
                "~/Scripts/AdminLogin/daterangepicker.js",
                "~/Scripts/AdminLogin/countdowntime.js",
                "~/Scripts/AdminLogin/main.js"

            ));

            bundles.Add(new ScriptBundle("~/bundles/frontmain").Include(
                "~/Scripts/FrontJS/jquery.js",
                "~/Scripts/FrontJS/jquery-migrate.min.js",
                "~/Scripts/FrontJS/modernizr-2.6.2.min.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/frontmain2").Include(
                "~/Scripts/FrontJS/be-modules-plugin.js",
                "~/Scripts/FrontJS/plugins.js",
                "~/Scripts/FrontJS/script.js",
                "~/Scripts/FrontJS/jquery.countdown.min.js",
                "~/Scripts/FrontJS/be-modules-script.js",
                "~/Scripts/FrontJS/frontend/add-to-cart.min.js",
                "~/Scripts/FrontJS/jquery-blockui/jquery.blockUI.min.js",
                "~/Scripts/FrontJS/frontend/woocommerce.min.js",
                "~/Scripts/FrontJS/jquery-cookie/jquery.cookie.min.js",
                "~/Scripts/FrontJS/frontend/cart-fragments.min.js",
                "~/Scripts/FrontJS/woocommerce.js",
                "~/Scripts/FrontJS/bb-press.js",
                "~/Scripts/FrontJS/be-slider.js",
                "~/Scripts/FrontJS/jquery-ui-1.8.22.custom.min.js",
                "~/Scripts/jquery-ui-{version}.js",
                "~/Scripts/FrontJS/masterslider.min.js",
                "~/Scripts/FrontJS/jquery.easing.min.js",
                "~/Scripts/FrontJS/chosen/chosen.jquery.min.js",
                "~/Scripts/FrontJS/frontend/chosen-frontend.min.js"
            ));
            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好可進行生產時，請使用 https://modernizr.com 的建置工具，只挑選您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/themes/base/jquery-ui.css",
                "~/Content/bootstrap.css",
                "~/Content/FrontCss/carts.css",
                      "~/Content/FrontCss/layout.css",
                      "~/Content/FrontCss/shortcodes.css",
                      "~/Content/FrontCss/settings.css",
                      "~/Content/FrontCss/woocommerce.css",
                      "~/Content/FrontCss/bb-press.css",
                      "~/Content/FrontCss/style.css",
                      "~/Content/FrontCss/theme-options.css",
                      "~/Content/FrontCss/icons.css",
                      "~/Content/FrontCss/magnific-popup.css",
                      "~/Content/FrontCss/flexslider.css",
                      "~/Content/FrontCss/animate-custom.css",
                      "~/Content/FrontCss/be-slide.css",
                      "~/Content/FrontCss/masterslider.main.css",
                      "~/Content/FrontCss/custom.css",
                      "~/Content/FrontCss/chosen.css",
                      "~/Content/FrontCss/prettyPhoto.css",
                      "~/Content/FrontCss/font-awesome.css",
                "~/Content/FrontCss/view-component.css"
                

                ));

            bundles.Add(new StyleBundle("~/Content/css/admin").Include(
                "~/Content/themes/base/jquery-ui.css",
                "~/Content/bootstrap.css",
                "~/Content/AdminCss/jquery-jvectormap-1.2.2.css",
                "~/Content/AdminCss/AdminLTE.css",
                "~/Content/AdminCss/skin-yellow-light.css",
                "~/Content/AdminCss/component.css",
                "~/Content/AdminCss/process-dialog.css"
              
            ));

            bundles.Add(new StyleBundle("~/Content/css/adminlogin").Include(
                "~/Content/AdminLogin/favicon.ico",
                "~/Content/bootstrap.css",
                "~/Content/FrontCss/font-awesome.css",
                "~/Content/AdminLogin/icon-font.min.css",
                "~/Content/AdminLogin/animate.css",
                "~/Content/AdminLogin/hamburgers.css",
                "~/Content/AdminLogin/animsition.css",
                "~/Content/AdminLogin/select2.css",
                "~/Content/AdminLogin/daterangepicker.css",
                 "~/Content/AdminLogin/util.css",
                  "~/Content/AdminLogin/main.css"
            ));

            BundleTable.EnableOptimizations = false;
        }
    }
}
