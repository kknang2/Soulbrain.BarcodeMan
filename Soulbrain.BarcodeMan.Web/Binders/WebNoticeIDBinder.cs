using Soulbrain.BarcodeMan.Dtos.WebNotice;
using System.Web;
using System.Web.Mvc;

namespace Soulbrain.BarcodeMan.Web.Binders
{
    public class WebNoticeIDBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;

            return new WebNoticeID()
            {
                PlantCode = request.Params.Get("plantCode"),
                DocCode = request.Params.Get("DocCode"),
            };
        }
    }
}