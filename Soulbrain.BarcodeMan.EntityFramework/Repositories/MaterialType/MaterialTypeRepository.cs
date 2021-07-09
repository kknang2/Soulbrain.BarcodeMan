using AutoMapper;
using Soulbrain.BarcodeMan.Domain;
using Soulbrain.BarcodeMan.Dtos.MaterialType;
using Soulbrain.BarcodeMan.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Soulbrain.BarcodeMan.Repositories
{
    /// <summary>
    /// 자재유형정보
    /// </summary>
    public class MaterialTypeRepository : BaseRepository<MaterialType>, IMaterialTypeRepository
    {
        /// <summary>
        /// UseFlag="T" 레코드 조회
        /// </summary>
        public IQueryable<MaterialType> ActiveEntities
        {
            get
            {
                return Entities.Where(t => t.UseFlag.Equals(StrBool.True));
            }
        }

        /// <summary>
        /// 제품팝업조회 자재유형콤보
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MaterialTypeSelectItem> GetMaterialTypeSelectItems()
        {
            var list = ActiveEntities.AsEnumerable();

            return Mapper.Map<IEnumerable<MaterialTypeSelectItem>>(list);
        }
    }
}
