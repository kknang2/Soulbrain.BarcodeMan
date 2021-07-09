using AutoMapper;
using PagedList;
using Soulbrain.BarcodeMan.Domain;
using Soulbrain.BarcodeMan.Dtos.WebBoard;
using System.Collections.Generic;
using System.Linq;

namespace Soulbrain.BarcodeMan.Repositories
{
    /// <summary>
    /// 업무게시판 정보
    /// </summary>
    public class WebBoardRepository : BaseRepository<WebBoard>, IWebBoardRepository
    {
        /// <summary>
        /// 업무게시판 페이지 정보
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IPagedList<WebBoardListItem> GetBoardPagedList(WebBoardListFilter filter)
        {
            IPagedList<WebBoardListItem> boardList = Entities
                .OrderByDescending(b => b.CreateDate)
                .Where(b => b.VendorCode.Equals(filter.VendorCode))
                .Where(b => string.IsNullOrEmpty(filter.Title) || b.TitleKor.Contains(filter.Title) || b.TitleEng.Contains(filter.Title))
                .Select(b => new WebBoardListItem()
                {
                    PlantCode = b.PlantCode,
                    DocCode = b.DocCode,
                    TitleKor = b.TitleKor,
                    TitleEng = b.TitleEng,
                    BoardType = b.BoardType,
                    WriteDate = b.WriteDate,
                    WriteID = b.WriteID,
                    Comments = b.Comments.Count,
                    HasAttachment = b.Attachments.FirstOrDefault() != null
                })
                .ToPagedList(filter.PageNumber, filter.PageSize);

            return boardList;
        }

        /// <summary>
        /// 업무게시판 상세
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WebBoardDetail GetBoardDetail(WebBoardID id)
        {
            var board = Entities
                .Where(b => b.PlantCode.Equals(id.PlantCode) && b.DocCode.Equals(id.DocCode) && b.VendorCode.Equals(id.VendorCode))
                .FirstOrDefault();

            return Mapper.Map<WebBoardDetail>(board);
        }

        /// <summary>
        /// 기본 페이지 업무게시판
        /// </summary>
        /// <param name="vendorCode"></param>
        /// <returns></returns>
        public IList<WebBoardListItem> GetRecentBoardList(string vendorCode)
        {
            IList<WebBoard> boardList = Entities
                .Where(b => b.VendorCode.Equals(vendorCode))
                .OrderByDescending(b => b.CreateDate)
                .Take(AppConsts.RecentBoardListLimit)
                .ToList();

            return Mapper.Map<IList<WebBoardListItem>>(boardList);
        }
    }
}
