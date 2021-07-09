using Soulbrain.BarcodeMan.Authenticate;
using Soulbrain.BarcodeMan.Dtos.WebBoard;
using Soulbrain.BarcodeMan.Web.Authenticate;
using Soulbrain.BarcodeMan.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Soulbrain.BarcodeMan.Web.Binders
{
    public class WebBoardListFilterBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;
            User user = (User)controllerContext.HttpContext.Session[SessionKeys.UserInfo];

            var model = new WebBoardListFilter();

            if (!string.IsNullOrEmpty(request.Params.Get("page")))
            {
                model.PageNumber = Convert.ToInt32(request.Params.Get("page"));
            }

            if (!string.IsNullOrEmpty(request.Params.Get("size")))
            {
                model.PageSize = Convert.ToInt32(request.Params.Get("size"));
            }

            model.Title = request.Params.Get("title");
            model.VendorCode = user.VendorCode;

            return model;
        }
    }
}