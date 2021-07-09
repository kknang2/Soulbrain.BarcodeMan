using Soulbrain.BarcodeMan.Authenticate;
using Soulbrain.BarcodeMan.Domain;
using System.Linq;
using AutoMapper;
using Soulbrain.BarcodeMan.Enums;

namespace Soulbrain.BarcodeMan.Repositories
{
    /// <summary>
    /// 업체별 사용자 정보
    /// </summary>
    public class VendorPRepository : BaseRepository<VendorP>, IVendorPRepository
    {
        public IQueryable<VendorP> ActiveEntities
        {
            get
            {
                return Entities.Where(vp => vp.UseFlag.Equals(StrBool.True));
            }
        }

        /// <summary>
        /// 비밀번호 변경
        /// </summary>
        /// <param name="personID"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ChangePassword(string personID, string password)
        {
            VendorP person = ActiveEntities
                .Where(vp => vp.PersonID.Equals(personID))
                .FirstOrDefault();

            person.PersonPW = password;

            _context.SaveChanges();

            return true;
        }

        /// <summary>
        /// 사용자 정보 얻기
        /// </summary>
        /// <param name="personID"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User GetUserByCredentials(string personID, string password)
        {
            VendorP person = ActiveEntities
                .Where(vp => vp.PersonID.Equals(personID))
                .Where(vp => vp.PersonPW.Equals(password))
                .FirstOrDefault();

            return Mapper.Map<User>(person);
        }

        /// <summary>
        /// 아이디로 사용자정보 얻기
        /// </summary>
        /// <param name="personID"></param>
        /// <returns></returns>
        public User GetUserByPersonID(string personID)
        {
            VendorP person = ActiveEntities
                .Where(vp => vp.PersonID.Equals(personID))
                .FirstOrDefault();

            return Mapper.Map<User>(person);
        }
    }
}
