using PagedList;
using Soulbrain.BarcodeMan.Dtos.WebNotice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Soulbrain.BarcodeMan.Web.Models.Notice
{
    public class NoticeList
    {
        public IPagedList<WebNoticeListItem> WebNoticeListItems { get; set; }

        public WebNoticeListFilter Filter { get; set; }
    }
}