using PagedList;
using Soulbrain.BarcodeMan.Dtos.WebBoard;
using System.Collections.Generic;

namespace Soulbrain.BarcodeMan.Repositories
{
    public interface IWebBoardRepository
    {
        WebBoardDetail GetBoardDetail(WebBoardID id);

        IList<WebBoardListItem> GetRecentBoardList(string vendorCode);

        IPagedList<WebBoardListItem> GetBoardPagedList(WebBoardListFilter filter);
    }
}
