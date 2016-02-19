using System.Web.Optimization;

namespace ProxyGeneratorDemoPage
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/myScripts").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/angular.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/angularApp")
                .IncludeDirectory("~/ControllersProxies/", "*.js", false)
                .IncludeDirectory("~/ScriptsApp/Classes/", "*.js", false)
                .Include(
                    "~/ScriptsApp/jQueryJsCalls.js",
                    "~/ScriptsApp/jQueryCalls.js",
                    "~/ScriptsApp/Directives/fileUpload.js",
                    "~/ScriptsApp/Views/Proxy/proxyCtrl.js",
                    "~/ScriptsApp/Views/mainApp.js",
                    "~/Scripts/Enums.js" //Generated Enums from TypeLite
                    ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
