using Soulbrain.BarcodeMan.Dtos.Product;
using Soulbrain.BarcodeMan.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Soulbrain.BarcodeMan.Web.Models.Barcode
{
    public class Print
    {
        public Print()
        {
            UnitSelectList = UnitCodes.SelectListItems;
            ExpDateSelectList = ExpDateCodes.SelectListItems;
        }

        public PopupProduct PopupProduct { get; set; }

        public IList<SelectListItem> UnitSelectList { get; set; }

        public IList<SelectListItem> ExpDateSelectList { get; set; }
    }
}