using Soulbrain.BarcodeMan.Domain;
using Soulbrain.BarcodeMan.EntityFramework;
using Soulbrain.BarcodeMan.Enums;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace Soulbrain.BarcodeMan.Migrations.SeedData
{
    public class VendorsCreator
    {
        private readonly AppDbContext _context;

        public VendorsCreator(AppDbContext context)
        {
            _context = context;
        }
            
        public void Create()
        {
            var vendors = new List<Vendor>
            {
                new Vendor { VendorCode = "10000", VendorName = @"덕산화학", VendorNameEn = "Duksan Chemical", UseFlag = StrBool.True},
                new Vendor { VendorCode = "10003", VendorName = @"(주)영진", UseFlag = StrBool.True},
                new Vendor { VendorCode = "10006", VendorName = @"(주)천보정밀", UseFlag = StrBool.True},
                new Vendor { VendorCode = "10008", VendorName = @"삼성물산(주)", UseFlag = StrBool.True},
                new Vendor { VendorCode = "10012", VendorName = @"유피시스템(주)", UseFlag = StrBool.True},
                new Vendor { VendorCode = "10024", VendorName = @"(주)한솔케미칼 전주공장", UseFlag = StrBool.True},
                new Vendor { VendorCode = "10033", VendorName = @"휴켐스(주)여수공장", UseFlag = StrBool.True},
            };

            vendors.ForEach(s => _context.Vendors.AddOrUpdate(s));
            _context.SaveChanges();
        }
    }
}
