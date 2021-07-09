using Soulbrain.BarcodeMan.Domain;
using Soulbrain.BarcodeMan.EntityFramework;
using Soulbrain.BarcodeMan.Enums;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace Soulbrain.BarcodeMan.Migrations.SeedData
{
    public class VendorPsCreator
    {
        private readonly AppDbContext _context;

        public VendorPsCreator(AppDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var vendorPs = new List<VendorP>
            {
                new VendorP { VendorCode = "10000", Seq=1, PersonID="hongkd", PersonPW="123qwe", PersonName = @"홍길동", UseFlag = StrBool.True},
                new VendorP { VendorCode = "10003", Seq=2, PersonID="kimcs", PersonPW="123qwe", PersonName = @"김철수", UseFlag = StrBool.True},
                new VendorP { VendorCode = "10006", Seq=3, PersonID="leeys", PersonPW="123qwe", PersonName = @"이영수", UseFlag = StrBool.True},
            };

            vendorPs.ForEach(s => _context.VendorPs.AddOrUpdate(s));
            _context.SaveChanges();
        }
    }
}
