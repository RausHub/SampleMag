using System.Web;
using System.Web.Optimization;

namespace Music
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-2.6.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/vendors").Include(
                "~/Scripts/vendors/jquery-3.2.1.js",
                "~/Scripts/vendors/bootstrap.js",
                "~/Scripts/vendors/angular.js",
                "~/Scripts/vendors/respond.src.js",
                "~/Scripts/vendors/angular-base64.js",
                "~/Scripts/vendors/toastr.js",                
                "~/Scripts/vendors/angular-route.js",
                "~/Scripts/vendors/angular-cookies.js",
                "~/Scripts/vendors/angular-resource.js",
                "~/Scripts/vendors/ng-videosharing-embed.min.js",
                "~/Scripts/vendors/angucomplete-alt.min.js",                
                "~/Scripts/vendors/ui-bootstrap-2.5.0.js"
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
                "~/content/bootstrap2.css",
                "~/content/site.css",
                "~/content/angular-toastr.css"));

            BundleTable.EnableOptimizations = false;
        }
    }
}
