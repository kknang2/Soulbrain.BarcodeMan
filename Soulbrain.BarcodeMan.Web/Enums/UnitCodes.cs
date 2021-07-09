using Soulbrain.BarcodeMan.Enums;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Soulbrain.BarcodeMan.Web.Enums
{
    public class UnitCodes
    {
        public static IList<SelectListItem> SelectListItems
        {
            get
            {
                IList<SelectListItem> listItems = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Text = UnitCode.Gram,
                        Value = UnitCode.Gram
                    },
                    new SelectListItem
                    {
                        Text = UnitCode.Kilogram,
                        Value = UnitCode.Kilogram
                    },
                    new SelectListItem
                    {
                        Text = UnitCode.Litre,
                        Value = UnitCode.Litre
                    },
                    new SelectListItem
                    {
                        Text = UnitCode.Mmillilitre,
                        Value = UnitCode.Mmillilitre
                    }
                };
                return listItems;
            }
        }
    }
}