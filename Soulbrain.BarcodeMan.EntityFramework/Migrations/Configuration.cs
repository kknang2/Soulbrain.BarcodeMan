using Soulbrain.BarcodeMan.EntityFramework;
using Soulbrain.BarcodeMan.Migrations.SeedData;
using System.Data.Entity.Migrations;

namespace Soulbrain.BarcodeMan.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppDbContext context)
        {
            new VendorsCreator(context).Create();
            new VendorPsCreator(context).Create();
            new WebNoticesCreator(context).Create();
            new WebBoardsCreator(context).Create();
            new MaterialTypesCreator(context).Create();
            new MaterialGroupsCreator(context).Create();
            new ProductsCreator(context).Create();
            new WebBarCodesCreator(context).Create();
            new ProductVendorsCreator(context).Create();
        }
    }
}
