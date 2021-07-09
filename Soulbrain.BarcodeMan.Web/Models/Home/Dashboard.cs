using Soulbrain.BarcodeMan.Dtos.WebBoard;
using Soulbrain.BarcodeMan.Dtos.WebNotice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Soulbrain.BarcodeMan.Web.Models.Home
{
    public class Dashboard
    {
        public IList<WebNoticeListItem> WebNoticeList { get; set; }
        public IList<WebBoardListItem> WebBoardList { get; set; }
    }
}