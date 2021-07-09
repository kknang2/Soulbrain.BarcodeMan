using PagedList;
using Soulbrain.BarcodeMan.Dtos.WebBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Soulbrain.BarcodeMan.Web.Models.Board
{
    public class BoardList
    {
        public IPagedList<WebBoardListItem> WebBoardListItems { get; set; }

        public WebBoardListFilter Filter { get; set; }
    }
}