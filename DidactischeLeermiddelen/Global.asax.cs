using DidactischeLeermiddelen.Infrastructure;
using DidactischeLeermiddelen.Models.DAL;
using DidactischeLeermiddelen.Models.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DidactischeLeermiddelen
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            TeachingAidsContext db = new TeachingAidsContext();
            db.Database.Initialize(true);

            ModelBinders.Binders.Add(typeof(User), new UserModelBinder());

        }
    }
}
