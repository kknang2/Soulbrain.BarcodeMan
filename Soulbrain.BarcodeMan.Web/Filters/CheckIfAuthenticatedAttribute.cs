using Soulbrain.BarcodeMan.Authenticate;
using Soulbrain.BarcodeMan.Web.Authenticate;
using System.Web.Mvc;

namespace Soulbrain.BarcodeMan.Web.Filters
{
    public class CheckIfAuthenticatedAttribute : FilterAttribute, IAuthorizationFilter
    {
        public CheckIfAuthenticatedAttribute()
        {
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            IAuthProvider _authProvider = new AuthProvider(filterContext.HttpContext);

            // If current user is a guest
            if (_authProvider.IsGuest)
            {
                // Redirect to login action
                filterContext.Result = new RedirectResult("/Account/Login?returnUrl=" + filterContext.HttpContext.Request.Url);
            }
        }
    }
}