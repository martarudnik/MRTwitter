using System.Web.Optimization;

namespace MRTwitter.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.12.0.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/unobtrusive").Include(
                    "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/html5shiv").Include(
                      "~/Scripts/html5shiv.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/screen.css"));
        }
    }
}