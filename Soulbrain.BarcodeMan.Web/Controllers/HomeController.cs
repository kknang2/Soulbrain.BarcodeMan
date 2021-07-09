using Soulbrain.BarcodeMan.Web.Filters;
using Soulbrain.BarcodeMan.Helpers;
using System;
using System.Web;
using System.Web.Mvc;
using Soulbrain.BarcodeMan.Web.Models.Home;
using Soulbrain.BarcodeMan.Repositories;

namespace Soulbrain.BarcodeMan.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IWebNoticeRepository _webNoticeRepo;
        private readonly IWebBoardRepository _webBoardRepo;

        public HomeController(
            IWebNoticeRepository webNoticeRepo,
            IWebBoardRepository webBoardRepo
            )
        {
            _webNoticeRepo = webNoticeRepo;
            _webBoardRepo = webBoardRepo;
        }

        /// <summary>
        /// 홈페이지
        /// </summary>
        /// <returns></returns>
        [CheckIfAuthenticated]
        public ActionResult Index()
        {
            Dashboard model = new Dashboard()
            {
                WebNoticeList = _webNoticeRepo.GetRecentNoticeList(),
                WebBoardList = _webBoardRepo.GetRecentBoardList(_authProvider.User.VendorCode)
            };
            return View("Index", model);
        }

        /// <summary>
        /// 언어설정
        /// </summary>
        /// <param name="culture"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SetCulture(string culture, string returnUrl)
        {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);
            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {
                cookie = new HttpCookie("_culture")
                {
                    Value = culture,
                    Expires = DateTime.Now.AddYears(1)
                };
            }
            Response.Cookies.Add(cookie);

            return Redirect(returnUrl);
        }
    }
}