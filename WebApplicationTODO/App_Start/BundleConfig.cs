using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WebApplicationTODO.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/assets/css").Include(
                        "~/assets/css/style-starter.css"));

            bundles.Add(new ScriptBundle("~/assets/js").Include(
                    "~/assets/js/bootstrap.min.js",
                    "~/assets/js/circles.js",
                    "~/assets/js/jquery-3.3.1.min.js",
                    "~/assets/js/owl.carousel.js",
                    "~/assets/js/theme-change.js"
                    ));

        }
    }
}