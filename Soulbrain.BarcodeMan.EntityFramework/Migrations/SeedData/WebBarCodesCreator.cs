using Soulbrain.BarcodeMan.Domain;
using Soulbrain.BarcodeMan.EntityFramework;
using Soulbrain.BarcodeMan.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace Soulbrain.BarcodeMan.Migrations.SeedData
{
    public class WebBarCodesCreator
    {
        private readonly AppDbContext _context;

        public WebBarCodesCreator(AppDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var barcodes = new List<WebBarCode>
            {
                new WebBarCode { PlantCode = "1100", DocCode = "1811160001", ProductCode = "40000001", SupplyQty = 36, PackingUnitCode = UnitCode.Kilogram, LotNo = "18111601", ProductDate = DateTime.Now.Date.ToString("yyyy-MM-dd"), ExpDateCode = ExpDateCode.M6, PrintQty = 3, PrintDatetime = DateTime.Now, PrintType = "B", SupplyDate = DateTime.Now.ToString("yyyy-MM-dd") },
                new WebBarCode { PlantCode = "1100", DocCode = "1811160002", ProductCode = "40000002", SupplyQty = 100, PackingUnitCode = UnitCode.Litre, LotNo = "18111602", ProductDate = DateTime.Now.Date.ToString("yyyy-MM-dd"), ExpDateCode = ExpDateCode.M6, PrintQty = 2, PrintDatetime = DateTime.Now, PrintType = "S", SupplyDate = DateTime.Now.ToString("yyyy-MM-dd") },
            };

            barcodes.ForEach(b => _context.WebBarCodes.AddOrUpdate(b));
            _context.SaveChanges();
        }
    }
}
