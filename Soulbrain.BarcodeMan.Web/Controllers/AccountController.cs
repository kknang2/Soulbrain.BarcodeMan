using Soulbrain.BarcodeMan.Resources;
using Soulbrain.BarcodeMan.Web.Models.Account;
using System.Web.Mvc;

namespace Soulbrain.BarcodeMan.Web.Controllers
{
    public class AccountController : BaseController
    {
        /// <summary>
        /// 로그인
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public ActionResult Login(string returnUrl)
        {
            if (!_authProvider.IsGuest)
            {
                return RedirectToAction("Index", "Home");
            }

            Login model = new Login()
            {
                ReturnUrl = returnUrl
            };

            return View("Login", model);
        }

        /// <summary>
        /// 로그인확인
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(Login model)
        {
            if (_authProvider.AttemptLogin(model.UserId, model.Password, model.RememberMe))
            {
                if (!string.IsNullOrEmpty(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("Password", "");
            return View("Login", model);
        }

        /// <summary>
        /// 비밀번호변경
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ChangePW(ChangePassword model)
        {
            if (_authProvider.CheckPasswordValid(model.CurrentPassword))
            {
                if (_authProvider.ChangePassword(model.NewPassword))
                {
                    return Json(new
                    {
                        status = 200,
                        message = Message.PW_MSG_PWChanged
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new
            {
                status = 400,
                message = Message.PW_MSG_InvalidPW
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 로그아웃
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            _authProvider.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}