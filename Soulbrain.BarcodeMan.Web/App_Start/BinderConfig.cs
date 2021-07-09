using Soulbrain.BarcodeMan.Dtos.WebBarCode;
using Soulbrain.BarcodeMan.Dtos.WebBoard;
using Soulbrain.BarcodeMan.Dtos.WebNotice;
using Soulbrain.BarcodeMan.Web.Binders;
using System.Web.Mvc;

namespace Soulbrain.BarcodeMan.Web
{
    public class BinderConfig
    {
        public static void RegisterBinders()
        {
            ModelBinders.Binders.Add(typeof(WebNoticeListFilter), new WebNoticeListFilterBinder());
            ModelBinders.Binders.Add(typeof(WebBoardListFilter), new WebBoardListFilterBinder());
            ModelBinders.Binders.Add(typeof(WebNoticeID), new WebNoticeIDBinder());
            ModelBinders.Binders.Add(typeof(WebBoardID), new WebBoardIDBinder());
            ModelBinders.Binders.Add(typeof(WebBarCodeListFilter), new WebBarCodeListFilterBinder());
        }
    }
}