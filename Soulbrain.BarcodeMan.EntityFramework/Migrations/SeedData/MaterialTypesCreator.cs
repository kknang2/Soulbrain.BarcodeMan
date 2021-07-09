using Soulbrain.BarcodeMan.Domain;
using Soulbrain.BarcodeMan.EntityFramework;
using Soulbrain.BarcodeMan.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulbrain.BarcodeMan.Migrations.SeedData
{
    public class MaterialTypesCreator
    {
        private readonly AppDbContext _context;

        public MaterialTypesCreator(AppDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var mTypes = new List<MaterialType>
            {
                new MaterialType { PlantCode = "1100", MaterialTypeCode = "ETC", MaterialTypeName = @"기타", MaterialTypeNameEn = "Other", UseFlag = StrBool.False},
                new MaterialType { PlantCode = "1100", MaterialTypeCode = "FERT", MaterialTypeName = @"완제품", MaterialTypeNameEn = "Finished", UseFlag = StrBool.True},
                new MaterialType { PlantCode = "1100", MaterialTypeCode = "HALB", MaterialTypeName = @"중간제품", MaterialTypeNameEn = "Half", UseFlag = StrBool.True},
                new MaterialType { PlantCode = "1100", MaterialTypeCode = "ROH", MaterialTypeName = @"원자재", MaterialTypeNameEn = "Raw materials", UseFlag = StrBool.True},
                new MaterialType { PlantCode = "1100", MaterialTypeCode = "SAMP", MaterialTypeName = @"개발품", MaterialTypeNameEn = "Developments", UseFlag = StrBool.True},
            };

            mTypes.ForEach(s => _context.MaterialTypes.AddOrUpdate(s));
            _context.SaveChanges();
        }
    }
}
