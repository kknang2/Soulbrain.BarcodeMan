using Soulbrain.BarcodeMan.Authenticate;
using Soulbrain.BarcodeMan.Dtos.WebBoard;
using System.Web;
using System.Web.Mvc;

namespace Soulbrain.BarcodeMan.Web.Binders
{
    public class WebBoardIDBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;

            var user = (User)controllerContext.HttpContext.Session[SessionKeys.UserInfo];

            return new WebBoardID()
            {
                PlantCode = request.Params.Get("plantCode"),
                DocCode = request.Params.Get("DocCode"),
                VendorCode = user.VendorCode,
            };
        }
    }
}