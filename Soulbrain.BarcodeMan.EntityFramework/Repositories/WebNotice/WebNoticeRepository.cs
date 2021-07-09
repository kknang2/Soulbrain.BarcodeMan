using AutoMapper;
using PagedList;
using Soulbrain.BarcodeMan.Domain;
using Soulbrain.BarcodeMan.Dtos.WebNotice;
using System.Collections.Generic;
using System.Linq;

namespace Soulbrain.BarcodeMan.Repositories
{
    /// <summary>
    /// 공지사항
    /// </summary>
    public class WebNoticeRepository : BaseRepository<WebNotice>, IWebNoticeRepository
    {
        /// <summary>
        /// 공지사항 상세
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WebNoticeDetail GetNoticeDetail(WebNoticeID id)
        {
            var notice = Entities
                .Where(n => n.PlantCode.Equals(id.PlantCode) && n.DocCode.Equals(id.DocCode))
                .FirstOrDefault();

            return Mapper.Map<WebNoticeDetail>(notice);
        }

        /// <summary>
        /// 공지사항 페이지 정보
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IPagedList<WebNoticeListItem> GetNoticePagedList(WebNoticeListFilter filter)
        {
            IPagedList<WebNoticeListItem> noticeList = Entities
                .OrderByDescending(n => n.CreateDate)
                .Where(n => string.IsNullOrEmpty(filter.Title) || n.TitleKor.Contains(filter.Title) || n.TitleEng.Contains(filter.Title))
                .Select(n => new WebNoticeListItem()
                {
                    PlantCode = n.PlantCode,
                    DocCode = n.DocCode,
                    TitleKor = n.TitleKor,
                    TitleEng = n.TitleEng,
                    NoticeType = n.NoticeType,
                    WriteDate = n.WriteDate,
                    WriteID = n.WriteID,
                    HasAttachment = n.Attachments.FirstOrDefault() != null
                })
                .ToPagedList(filter.PageNumber, filter.PageSize);

            return noticeList;
            //return noticeList.Select(x => Mapper.Map(x, typeof(WebNotice), typeof(WebNoticeListItem)));
        }

        /// <summary>
        /// 기본 페이지 공지사항
        /// </summary>
        /// <returns></returns>
        public IList<WebNoticeListItem> GetRecentNoticeList()
        {
            IList<WebNotice> noticeList = Entities
                .OrderByDescending(n => n.CreateDate)
                .Take(AppConsts.RecentNoticeListLimit)
                .ToList();

            return Mapper.Map<IList<WebNoticeListItem>>(noticeList);
        }
    }
}
