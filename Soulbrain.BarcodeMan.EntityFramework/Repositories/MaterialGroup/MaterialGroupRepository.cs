using AutoMapper;
using Soulbrain.BarcodeMan.Domain;
using Soulbrain.BarcodeMan.Dtos.MaterialGroup;
using Soulbrain.BarcodeMan.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulbrain.BarcodeMan.Repositories
{
    /// <summary>
    /// 자재그룹정보
    /// </summary>
    public class MaterialGroupRepository : BaseRepository<MaterialGroup>, IMaterialGroupRepository
    {
        /// <summary>
        /// UseFlag="T" 레코드 조회
        /// </summary>
        public IQueryable<MaterialGroup> ActiveEntities
        {
            get
            {
                return Entities.Where(g => g.UseFlag.Equals(StrBool.True));
            }
        }

        /// <summary>
        /// 제품팝업조회 자재그룹콤보
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MaterialGroupSelectItem> GetMaterialGroupSelectItems()
        {
            var list = ActiveEntities.AsEnumerable();

            return Mapper.Map<IEnumerable<MaterialGroupSelectItem>>(list);
        }
    }
}
