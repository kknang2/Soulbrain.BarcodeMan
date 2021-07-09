using Soulbrain.BarcodeMan.Dtos.Comment;
using Soulbrain.BarcodeMan.Dtos.WebBoard;
using Soulbrain.BarcodeMan.Repositories;
using Soulbrain.BarcodeMan.Web.Binders;
using Soulbrain.BarcodeMan.Web.Filters;
using Soulbrain.BarcodeMan.Web.Models.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Soulbrain.BarcodeMan.Web.Controllers
{
    public class BoardController : BaseController
    {
        private readonly IWebBoardRepository _webBoardRepo;
        private readonly IWebBoardCommentRepository _commentRepo;

        public BoardController(
            IWebBoardRepository webBoardRepo,
            IWebBoardCommentRepository commentRepo
            )
        {
            _webBoardRepo = webBoardRepo;
            _commentRepo = commentRepo;
        }

        /// <summary>
        /// 업무게시판
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [CheckIfAuthenticated]
        public ActionResult Index([ModelBinder(typeof(WebBoardListFilterBinder))] WebBoardListFilter filter)
        {
            BoardList model = new BoardList()
            {
                WebBoardListItems = _webBoardRepo.GetBoardPagedList(filter),
                Filter = filter
            };

            return View(model);
        }

        /// <summary>
        /// 업무게시판 상세
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [CheckIfAuthenticated]
        public ActionResult Detail([ModelBinder(typeof(WebBoardIDBinder))] WebBoardID id)
        {

            var webBoardDetail = _webBoardRepo.GetBoardDetail(id);
            if (webBoardDetail == null)
            {
                return RedirectToAction("Index");
            }

            BoardDetail model = new BoardDetail()
            {
                WebBoardDetail = webBoardDetail,
                CommentInput = new CommentInput()
                {
                    PlantCode = id.PlantCode,
                    DocCode = id.DocCode
                }
            };

            return View(model);
        }

        /// <summary>
        /// 댓글 저장/변경
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Comment(CommentInput input)
        {
            var entity = _commentRepo.SaveComment(input);

            return Json(new
            {
                status = 200,
                data = new
                {
                    entity.Seq,
                    entity.WriteID,
                    WriteDatetime = entity.WriteDatetime.ToString()
                }
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 댓글 삭제
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteComment(CommentKey id)
        {
            _commentRepo.DeleteComment(id);

            return Json(new
            {
                status = 200
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 업무게시판 첨부파일 다운로드
        /// </summary>
        /// <param name="fileName">파일명</param>
        /// <returns></returns>
        public FileResult Download(string fileName)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(AppConsts.WebBoardAbsUploadPath + fileName);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}