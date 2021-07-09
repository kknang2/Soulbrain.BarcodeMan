using Soulbrain.BarcodeMan.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Soulbrain.BarcodeMan.Web.Models.Barcode
{
    public class PopupProduct
    {
        public PopupProduct()
        {
            Filter = new PopupProductListFilter();
        }

        public PopupProductListFilter Filter { get; set; }

        public IList<SelectListItem> MaterialTypeSelectList { get; set; }

        public IList<SelectListItem> MaterialGroupSelectList { get; set; }
    }
}