using Soulbrain.BarcodeMan.Domain;
using Soulbrain.BarcodeMan.EntityFramework;
using Soulbrain.BarcodeMan.Enums;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace Soulbrain.BarcodeMan.Migrations.SeedData
{
    public class MaterialGroupsCreator
    {
        private readonly AppDbContext _context;

        public MaterialGroupsCreator(AppDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var mGroups = new List<MaterialGroup>
            {
                new MaterialGroup { PlantCode = "1100", MaterialGroupCode = "L01", MaterialGroupName = @"제조1팀", MaterialGroupNameEn = "Manufacturing 1", UseFlag = StrBool.True},
                new MaterialGroup { PlantCode = "1100", MaterialGroupCode = "L02", MaterialGroupName = @"제조2팀", MaterialGroupNameEn = "Manufacturing 2", UseFlag = StrBool.True},
                new MaterialGroup { PlantCode = "1100", MaterialGroupCode = "L03", MaterialGroupName = @"제조3팀", MaterialGroupNameEn = "Manufacturing 3", UseFlag = StrBool.True},
                new MaterialGroup { PlantCode = "1100", MaterialGroupCode = "L04", MaterialGroupName = @"제조4팀", MaterialGroupNameEn = "Manufacturing 4", UseFlag = StrBool.True},
                new MaterialGroup { PlantCode = "1100", MaterialGroupCode = "L05", MaterialGroupName = @"제조5팀", MaterialGroupNameEn = "Manufacturing 5", UseFlag = StrBool.True},
                new MaterialGroup { PlantCode = "1100", MaterialGroupCode = "L06", MaterialGroupName = @"제조6팀", MaterialGroupNameEn = "Manufacturing 6", UseFlag = StrBool.True},
                new MaterialGroup { PlantCode = "1100", MaterialGroupCode = "L07", MaterialGroupName = @"제조7팀", MaterialGroupNameEn = "Manufacturing 7", UseFlag = StrBool.True},
                new MaterialGroup { PlantCode = "1100", MaterialGroupCode = "L08", MaterialGroupName = @"제조8팀", MaterialGroupNameEn = "Manufacturing 8", UseFlag = StrBool.True},
                new MaterialGroup { PlantCode = "1100", MaterialGroupCode = "L09", MaterialGroupName = @"제조9팀", MaterialGroupNameEn = "Manufacturing 9", UseFlag = StrBool.True},
                new MaterialGroup { PlantCode = "1100", MaterialGroupCode = "L10", MaterialGroupName = @"FECT제조팀", MaterialGroupNameEn = "Manufacturing FECT", UseFlag = StrBool.True},
                new MaterialGroup { PlantCode = "1100", MaterialGroupCode = "L11", MaterialGroupName = @"파주제조팀", MaterialGroupNameEn = "Manufacturing Paju", UseFlag = StrBool.True},
                new MaterialGroup { PlantCode = "1100", MaterialGroupCode = "L99", MaterialGroupName = @"TF팀", MaterialGroupNameEn = "IF Team", UseFlag = StrBool.True},
            };

            mGroups.ForEach(s => _context.MaterialGroups.AddOrUpdate(s));
            _context.SaveChanges();
        }
    }
}
