using Soulbrain.BarcodeMan.Authenticate;
using Soulbrain.BarcodeMan.Repositories;
using System.Web;

namespace Soulbrain.BarcodeMan.Web.Authenticate
{
    public class AuthProvider : IAuthProvider
    {
        private readonly IVendorPRepository _repo;
        private readonly HttpContextBase _context;
        private readonly User _user;

        public AuthProvider(HttpContextBase context)
        {
            _repo = new VendorPRepository();
            _context = context;
            _user = (User)context.Session[SessionKeys.UserInfo];
        }

        /// <summary>
        /// 가입자 정보
        /// </summary>
        public User User
        {
            get
            {
                return _user;
            }
        }

        /// <summary>
        /// 가입자 테스트
        /// </summary>
        public bool IsGuest
        {
            get
            {
                return _user == null;
            }
        }

        /// <summary>
        /// 로그인 정보 자료기지 조회
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <param name="rememberMe"></param>
        /// <returns></returns>
        public bool AttemptLogin(string userId, string password, bool rememberMe)
        {
            var user = _repo.GetUserByCredentials(userId, password);
            if (user != null)
            {
                _context.Session[SessionKeys.UserInfo] = user;

                return true;
            }

            return false;
        }

        /// <summary>
        /// 비밀번호 확인
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckPasswordValid(string password)
        {
            var user = _repo.GetUserByCredentials(_user.PersonID, password);
            if(user == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 비밀번호 변경
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ChangePassword(string password)
        {
            return _repo.ChangePassword(_user.PersonID, password);
        }

        /// <summary>
        /// 로그아웃
        /// </summary>
        public void Logout()
        {
            _context.Session.Remove(SessionKeys.UserInfo);
        }
    }
}