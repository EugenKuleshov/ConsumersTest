using System.Web.Optimization;

namespace ConsumersTest
{
    public class BundleConfig
    {
        // For more information on Bundling, visit https://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScriptsBudles(bundles);
            RegisterStylesBundles(bundles);
        }

        private static void RegisterScriptsBudles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                "~/Scripts/WebForms/WebForms.js",
                "~/Scripts/WebForms/WebUIValidation.js",
                "~/Scripts/WebForms/MenuStandards.js",
                "~/Scripts/WebForms/Focus.js",
                "~/Scripts/WebForms/GridView.js",
                "~/Scripts/WebForms/DetailsView.js",
                "~/Scripts/WebForms/TreeView.js",
                "~/Scripts/WebForms/WebParts.js"));

            // Order is very important for these files to work, they have explicit dependencies
            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                "~/Scripts/bootstrap-datepicker.js",
                "~/Scripts/alertify.js"
            ));
        }

        private static void RegisterStylesBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/style/custom")
                .Include("~/Content/bootstrap-datepicker3.css")
                .Include("~/Content/alertifyjs/alertify.css",
                         "~/Content/alertifyjs/themes/bootstrap.css")
                .IncludeDirectory("~/Content/custom", "*.css", true));
        }
    }
}