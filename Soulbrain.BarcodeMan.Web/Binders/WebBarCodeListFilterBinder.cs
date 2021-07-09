using Soulbrain.BarcodeMan.Authenticate;
using Soulbrain.BarcodeMan.Dtos.WebBarCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Soulbrain.BarcodeMan.Web.Binders
{
    public class WebBarCodeListFilterBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;

            var user = (User)controllerContext.HttpContext.Session[SessionKeys.UserInfo];

            var model = new WebBarCodeListFilter();

            if (!string.IsNullOrEmpty(request.Params.Get("page")))
            {
                model.PageNumber = Convert.ToInt32(request.Params.Get("page"));
            }

            if (!string.IsNullOrEmpty(request.Params.Get("size")))
            {
                model.PageSize = Convert.ToInt32(request.Params.Get("size"));
            }

            if (!string.IsNullOrEmpty(request.Params.Get("from")))
            {
                model.ProductDateFrom = DateTime.Parse(request.Params.Get("from"));
            }

            if (!string.IsNullOrEmpty(request.Params.Get("to")))
            {
                model.ProductDateTo = DateTime.Parse(request.Params.Get("to"));
            }

            model.VendorCode = user.VendorCode;
            model.LotNo = request.Params.Get("lotNo");
            model.ProductName = request.Params.Get("productName");
            model.OrderBy = request.Params.Get("orderBy");

            return model;
        }
    }
}