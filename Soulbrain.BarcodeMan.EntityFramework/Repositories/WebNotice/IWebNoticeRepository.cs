using PagedList;
using Soulbrain.BarcodeMan.Dtos.WebNotice;
using System.Collections.Generic;

namespace Soulbrain.BarcodeMan.Repositories
{
    public interface IWebNoticeRepository
    {
        WebNoticeDetail GetNoticeDetail(WebNoticeID id);

        IList<WebNoticeListItem> GetRecentNoticeList();

        IPagedList<WebNoticeListItem> GetNoticePagedList(WebNoticeListFilter filter);
    }
}
