using System.Web;
using System.Web.Optimization;

namespace SampleMag
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/libs/modernizr-2.6.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/vendors").Include(
                "~/Scripts/libs/jquery-3.2.1.js",
                "~/Scripts/libs/bootstrap.js",
                "~/Scripts/libs/angular.js",
                "~/Scripts/libs/respond.src.js",
                "~/Scripts/libs/angular-base64.js",
                "~/Scripts/libs/toastr.js",
                "~/Scripts/libs/angular-route.js",
                "~/Scripts/libs/angular-cookies.js",
                "~/Scripts/libs/angular-resource.js",
                "~/Scripts/libs/ng-videosharing-embed.min.js",
                "~/Scripts/libs/angucomplete-alt.min.js",
                "~/Scripts/libs/ui-bootstrap-2.5.0.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/spa").Include(
                "~/Scripts/app/modules/common.core.js",
                "~/Scripts/app/modules/common.ui.js",
                "~/Scripts/app/app.js",
                //account
                "~/Scripts/app/account/loginCtrl.js",
                "~/Scripts/app/account/registerCtrl.js",
                //home
                "~/Scripts/app/home/rootCtrl.js",
                "~/Scripts/app/home/indexCtrl.js",
                //layout
                "~/Scripts/app/layout/customPager.directive.js",
                "~/Scripts/app/layout/navbar.directive.js",
                //sample
                "~/Scripts/app/sample/sampleService.js",
                "~/Scripts/app/sample/createCtrl.js",
                "~/Scripts/app/sample/listsampleCtrl.js",
                //services
                "~/Scripts/app/services/apiService.js",
                "~/Scripts/app/services/membershipService.js",
                "~/Scripts/app/services/notificationService.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/content/css/bootstrap2.css",
                "~/content/css/site.css",
                "~/content/css/angular-toastr.css"));

            BundleTable.EnableOptimizations = false;
        }
    }
}

