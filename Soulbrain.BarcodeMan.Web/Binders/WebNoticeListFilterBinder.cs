using Soulbrain.BarcodeMan.Dtos.WebNotice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Soulbrain.BarcodeMan.Web.Binders
{
    public class WebNoticeListFilterBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;

            var model = new WebNoticeListFilter();

            if (!string.IsNullOrEmpty(request.Params.Get("page")))
            {
                model.PageNumber = Convert.ToInt32(request.Params.Get("page"));
            }

            if (!string.IsNullOrEmpty(request.Params.Get("size")))
            {
                model.PageSize = Convert.ToInt32(request.Params.Get("size"));
            }

            model.Title = request.Params.Get("title");

            return model;
        }
    }
}