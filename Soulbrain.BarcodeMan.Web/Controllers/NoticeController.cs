using Soulbrain.BarcodeMan.Dtos.WebNotice;
using Soulbrain.BarcodeMan.Repositories;
using Soulbrain.BarcodeMan.Web.Binders;
using Soulbrain.BarcodeMan.Web.Filters;
using Soulbrain.BarcodeMan.Web.Models.Notice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Soulbrain.BarcodeMan.Web.Controllers
{
    public class NoticeController : BaseController
    {
        private readonly IWebNoticeRepository _webNoticeRepo;

        public NoticeController(
            IWebNoticeRepository webNoticeRepo
            )
        {
            _webNoticeRepo = webNoticeRepo;
        }

        /// <summary>
        /// 공지사항
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [CheckIfAuthenticated]
        public ActionResult Index([ModelBinder(typeof(WebNoticeListFilterBinder))] WebNoticeListFilter filter)
        {
            NoticeList model = new NoticeList()
            {
                WebNoticeListItems = _webNoticeRepo.GetNoticePagedList(filter),
                Filter = filter
            };

            return View(model);
        }

        /// <summary>
        /// 공지사항 상세
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [CheckIfAuthenticated]
        public ActionResult Detail([ModelBinder(typeof(WebNoticeIDBinder))] WebNoticeID id)
        {
            var webNoticeDetail = _webNoticeRepo.GetNoticeDetail(id);
            if(webNoticeDetail == null)
            {
                return RedirectToAction("Index");
            }

            NoticeDetail model = new NoticeDetail()
            {
                WebNoticeDetail = webNoticeDetail
            };

            return View(model);
        }

        /// <summary>
        /// 공지사항 첨부파일 다운로드
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public FileResult Download(string fileName)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(AppConsts.NoticeAbsUploadPath + fileName);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}