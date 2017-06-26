using System.Web;
using System.Web.Optimization;

namespace ProyectoSoft2
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/js/libs/jquery-{version}.min.js",
                         "~/js/libs/jquery-ui-{version}.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/personalized").Include(
            "~/js/Layout.js"));

            bundles.Add(new ScriptBundle("~/bundles/smartadmin").Include(
            "~/js/app.config.js",
            "~/js/app.min.js",
            "~/js/bootstrap/bootstrap.min.js",
            "~/js/notification/SmartNotification.min.js",
            "~/js/smartwidgets/jarvis.widget.min.js",

            "~/js/plugin/jquery-touch/jquery.ui.touch-punch.min.js",
            "~/js/plugin/easy-pie-chart/jquery.easy-pie-chart.min.js",
            "~/js/plugin/sparkline/jquery.sparkline.min.js",
            "~/js/plugin/jquery-validate/jquery.validate.min.js",
            "~/js/plugin/masked-input/jquery.maskedinput.min.js",
            "~/js/plugin/select2/select2.min.js",
            "~/js/plugin/bootstrap-slider/bootstrap-slider.min.js",
            "~/js/plugin/msie-fix/jquery.mb.browser.min.js",
            "~/js/plugin/fastclick/fastclick.min.js",
             "~/js/plugin/jquey-form/jquery-form.min.js",

            "~/js/plugin/datatables/jquery.dataTables.min.js",
            "~/js/plugin/datatables/dataTables.bootstrap.min.js",
            "~/js/plugin/datatables/dataTables.colReorder.min.js",
            "~/js/plugin/datatables/dataTables.colVis.min.js",
            "~/js/plugin/datatables/dataTables.tableTools.min.js",
           "~/js/plugin/datatable-responsive/datatables.responsive.min.js",


           "~/js/plugin/ion-slider/ion.rangeSlider.min.js",
           "~/js/plugin/moment/moment.min.js",
           "~/js/plugin/fullcalendar/jquery.fullcalendar.min.js",
           "~/js/plugin/clockpicker/clockpicker.min.js",
           "~/js/plugin/x-editable/x-editable.min.js",
           "~/js/plugin/bootstrap-timepicker/bootstrap-timepicker.min.js",

           "~/js/plugin/bootstrap-wizard/jquery.bootstrap.wizard.min.js",
           "~/js/plugin/fuelux/wizard/wizard.min.js",
           "~/js/plugin/bootstrap-duallistbox/jquery.bootstrap-duallistbox.min.js"
          
           ));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/css/bootstrap.min.css",
                "~/css/font-awesome.min.css",

                "~/css/smartadmin-production.min.css",
                "~/css/smartadmin-skins.min.css",
                "~/css/smartadmin-rtl.min.css",
                "~/css/jarvis.widget.min.css",
                "~/css/lockscreen.css",
                  "~/css/smartadmin-production-plugins.min.css",
                "~/layout.css"
                ));

            bundles.Add(new StyleBundle("~/bundles/loginCss").Include(
                        "~/css/bootstrap.min.css",
                        "~/css/smartadmin-production.min.css",
                        "~/css/smartadmin-skins.min.css",
                        "~/Content/login.css",
                        "~/css/font-awesome.min.css"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/loginJs").Include(
                        "~/js/libs/jquery-{version}.min.js",
                        "~/js/libs/jquery-ui-{version}.min.js",
                        "~/js/bootstrap/bootstrap.min.js",
                        "~/js/plugin/jquery-validate/jquery.validate.min.js",
                        "~/js/plugin/masked-input/jquery.maskedinput.min.js",
                        "~/js/app.min.js"
                    ));
            BundleTable.EnableOptimizations = true;
        }

    }
}
