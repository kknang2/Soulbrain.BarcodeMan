using Soulbrain.BarcodeMan.Authenticate;
using Soulbrain.BarcodeMan.Web.Authenticate;
using Soulbrain.BarcodeMan.Helpers;
using System;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Soulbrain.BarcodeMan.Web.Controllers
{
    public class BaseController : Controller
    {
        protected IAuthProvider _authProvider;

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            _authProvider = new AuthProvider(requestContext.HttpContext);
        }

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureName = null;

            // Attempt to read the culture cookie from Request
            HttpCookie cultureCookie = Request.Cookies["_culture"];
            if (cultureCookie != null)
                cultureName = cultureCookie.Value;
            else
                cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ?
                        Request.UserLanguages[0] :  // obtain it from HTTP header AcceptLanguages
                        null;
            // Validate culture name
            cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe

            // Modify current thread's cultures            
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            var user = (User)_authProvider.User;

            if (user != null)
            {
                AuditInfo.PersonID = user.PersonID;
                AuditInfo.ClientIPAddress = Request.UserHostAddress;
            }

            ViewBag.User = user;
            return base.BeginExecuteCore(callback, state);
        }
    }

}