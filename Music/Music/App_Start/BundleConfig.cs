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
                "~/Scripts/jquery-1.10.2.js",
                "~/Scripts/bootstrap.js",               
                "~/Scripts/respond.src.js",
                "~/Scripts/angular.js",
                "~/Scripts/angular-route.js",
                "~/Scripts/angular-cookies.js",
                "~/Scripts/angular-resource.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/spa").Include(
                "~/Scripts/app/modules/common.core.js",
                "~/Scripts/app/app.js",
                "~/Scripts/app/account/loginCtrl.js",
                "~/Scripts/app/home/rootCtrl.js",
                "~/Scripts/app/home/indexCtrl.js",
                "~/Scripts/app/sample/createCtrl.js",
                "~/Scripts/app/sample/listsampleCtrl.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/content/site.css",
                "~/content/bootstrap.css"));

            BundleTable.EnableOptimizations = false;
        }
    }
}
