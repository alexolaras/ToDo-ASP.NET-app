using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace FinalWebTODO.App_Start
{
    public class BundleConfig
    {
         public static void RegisterBundles(BundleCollection bundles)
        {


            bundles.Add(new StyleBundle("~/assets/css").Include(
                        "~/assets/css/style-starter.css",
                        "~/assets/css/Eu.css"
                        ));

            bundles.Add(new ScriptBundle("~/assets/js").Include(
                    "~/assets/js/bootstrap.min.js",
                    "~/assets/js/circles.js",
                    "~/assets/js/jquery-3.3.1.min.js",
                    "~/assets/js/owl.carousel.js",
                    "~/assets/js/theme-change.js"
                    ));



            bundles.Add(new StyleBundle("~/assets/css2").Include(
                "~/assets/css2/style.css"
                ));

            bundles.Add(new ScriptBundle("~/assets/js2").Include(
                "~/assets/js2/fontawesome.js"
                ));

        }
    }
}