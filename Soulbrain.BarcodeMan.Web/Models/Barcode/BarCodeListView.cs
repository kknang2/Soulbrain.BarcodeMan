using PagedList;
using Soulbrain.BarcodeMan.Dtos.WebBarCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Soulbrain.BarcodeMan.Web.Models.Barcode
{
    public class BarCodeListView
    {
        public IPagedList<WebBarCodeListItem> WebBarCodeListItems;

        public WebBarCodeListFilter Filter;
    }
}