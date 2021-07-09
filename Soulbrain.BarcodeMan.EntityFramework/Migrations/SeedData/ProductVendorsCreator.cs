using Soulbrain.BarcodeMan.Domain;
using Soulbrain.BarcodeMan.EntityFramework;
using Soulbrain.BarcodeMan.Enums;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace Soulbrain.BarcodeMan.Migrations.SeedData
{
    public class ProductVendorsCreator
    {
        private readonly AppDbContext _context;

        public ProductVendorsCreator(AppDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var productVendors = new List<ProductVendor>
            {
                new ProductVendor { PlantCode = "1100", ProductCode = "40000001", Seq = 1, PrdVendorCode = "10000", PackingQty = 15, PackingUnitCode = UnitCode.Kilogram },
                new ProductVendor { PlantCode = "1100", ProductCode = "40000002", Seq = 2, PrdVendorCode = "10000", PackingQty = 7, PackingUnitCode = UnitCode.Kilogram },
                new ProductVendor { PlantCode = "1100", ProductCode = "40000003", Seq = 3, PrdVendorCode = "10000", PackingQty = 11, PackingUnitCode = UnitCode.Kilogram },
                new ProductVendor { PlantCode = "1100", ProductCode = "40000004", Seq = 4, PrdVendorCode = "10000", PackingQty = 2, PackingUnitCode = UnitCode.Litre },
                new ProductVendor { PlantCode = "1100", ProductCode = "40000005", Seq = 5, PrdVendorCode = "10000", PackingQty = 5, PackingUnitCode = UnitCode.Litre },
                new ProductVendor { PlantCode = "1100", ProductCode = "40000006", Seq = 1, PrdVendorCode = "10003", PackingQty = 2000, PackingUnitCode = UnitCode.Mmillilitre },
                new ProductVendor { PlantCode = "1100", ProductCode = "40000008", Seq = 2, PrdVendorCode = "10003", PackingQty = 1000, PackingUnitCode = UnitCode.Mmillilitre },
                new ProductVendor { PlantCode = "1100", ProductCode = "40000010", Seq = 3, PrdVendorCode = "10003", PackingQty = 350, PackingUnitCode = UnitCode.Gram },
            };

            productVendors.ForEach(s => _context.ProductVendors.AddOrUpdate(s));
            _context.SaveChanges();
        }

    }
}
