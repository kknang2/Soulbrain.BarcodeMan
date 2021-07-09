using Soulbrain.BarcodeMan.Dtos.WebBoard;
using Soulbrain.BarcodeMan.Dtos.WebNotice;
using Soulbrain.BarcodeMan.EntityFramework;
using Soulbrain.BarcodeMan.Web.Binders;
using System.Data.Entity.Infrastructure.Interception;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Soulbrain.BarcodeMan.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DtoMapperConfig.Configure();
            BinderConfig.RegisterBinders();

            DbInterception.Add(new DbInterceptorTransientErrors());
            DbInterception.Add(new DbInterceptorLogging());
        }
    }
}
