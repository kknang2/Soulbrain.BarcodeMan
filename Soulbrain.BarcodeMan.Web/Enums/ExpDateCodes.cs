using Soulbrain.BarcodeMan.Enums;
using Soulbrain.BarcodeMan.Resources;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Soulbrain.BarcodeMan.Web.Enums
{
    public class ExpDateCodes
    {
        public static IList<SelectListItem> SelectListItems
        {
            get
            {
                IList<SelectListItem> listItems = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Text = string.Format(Message.Text_ExpDateValue, ExpDateCode.M1),
                        Value = ExpDateCode.M1
                    },
                    new SelectListItem
                    {
                        Text = string.Format(Message.Text_ExpDateValue, ExpDateCode.M3),
                        Value = ExpDateCode.M3
                    },
                    new SelectListItem
                    {
                        Text = string.Format(Message.Text_ExpDateValue, ExpDateCode.M6),
                        Value = ExpDateCode.M6
                    },
                    new SelectListItem
                    {
                        Text = string.Format(Message.Text_ExpDateValue, ExpDateCode.M9),
                        Value = ExpDateCode.M9
                    },
                    new SelectListItem
                    {
                        Text = string.Format(Message.Text_ExpDateValue, ExpDateCode.M12),
                        Value = ExpDateCode.M12
                    },
                    new SelectListItem
                    {
                        Text = string.Format(Message.Text_ExpDateValue, ExpDateCode.M18),
                        Value = ExpDateCode.M18
                    },
                    new SelectListItem
                    {
                        Text = string.Format(Message.Text_ExpDateValue, ExpDateCode.M24),
                        Value = ExpDateCode.M24
                    }
                };
                return listItems;
            }
        }
    }
}