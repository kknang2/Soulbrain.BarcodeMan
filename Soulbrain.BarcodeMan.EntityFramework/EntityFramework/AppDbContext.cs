using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Soulbrain.BarcodeMan.Domain;

namespace Soulbrain.BarcodeMan.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public IDbSet<Vendor> Vendors { get; set; }
        public IDbSet<VendorP> VendorPs { get; set; }
        public IDbSet<MaterialGroup> MaterialGroups { get; set; }
        public IDbSet<MaterialType> MaterialTypes { get; set; }
        public IDbSet<ProductVendor> ProductVendors { get; set; }
        public IDbSet<Product> Products { get; set; }
        public IDbSet<WebBarCode> WebBarCodes { get; set; }
        public IDbSet<WebBoard> WebBoards { get; set; }
        public IDbSet<WebBoardComment> WebBoardComments { get; set; }
        public IDbSet<WebBoardFile> WebBoardFiles { get; set; }
        public IDbSet<WebBoardSearchHistory> WebBoardSearchHistories { get; set; }
        public IDbSet<WebNotice> WebNotices { get; set; }
        public IDbSet<WebNoticeFile> WebNoticeFiles { get; set; }
        public IDbSet<WebNoticeSearchHistory> WebNoticeSearchHistories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // decimals in Product
            modelBuilder.Entity<Product>()
                   .Property(x => x.ProductWeight)
                   .HasPrecision(10, 2);
            modelBuilder.Entity<Product>()
                   .Property(x => x.NetPrice)
                   .HasPrecision(15, 4);
            modelBuilder.Entity<Product>()
                   .Property(x => x.RealProductWeight)
                   .HasPrecision(10, 2);
            modelBuilder.Entity<Product>()
                   .Property(x => x.RecoverRate)
                   .HasPrecision(10, 2);
            modelBuilder.Entity<Product>()
                   .Property(x => x.PourWeight)
                   .HasPrecision(10, 2);
            modelBuilder.Entity<Product>()
                   .Property(x => x.WorkLotSize)
                   .HasPrecision(20, 5);
            modelBuilder.Entity<Product>()
                   .Property(x => x.SizePerPack)
                   .HasPrecision(20, 5);
            modelBuilder.Entity<Product>()
                   .Property(x => x.SizePerPack)
                   .HasPrecision(20, 5);

            // decimals in ProductVendor
            modelBuilder.Entity<ProductVendor>()
                   .Property(x => x.PackingQty)
                   .HasPrecision(15, 5);

            // decimals in ProductVendor
            modelBuilder.Entity<WebBarCode>()
                   .Property(x => x.SupplyQty)
                   .HasPrecision(15, 5);

            // using stored procedures
            modelBuilder.Entity<Vendor>()
                .MapToStoredProcedures();
            modelBuilder.Entity<VendorP>()
                .MapToStoredProcedures();
            modelBuilder.Entity<MaterialGroup>()
                .MapToStoredProcedures();
            modelBuilder.Entity<MaterialType>()
                .MapToStoredProcedures();
            modelBuilder.Entity<ProductVendor>()
                .MapToStoredProcedures();
            modelBuilder.Entity<Product>()
                .MapToStoredProcedures();
            modelBuilder.Entity<WebBarCode>()
                .MapToStoredProcedures();
            modelBuilder.Entity<WebBoard>()
                .MapToStoredProcedures();
            modelBuilder.Entity<WebBoardComment>()
                .MapToStoredProcedures();
            modelBuilder.Entity<WebBoardFile>()
                .MapToStoredProcedures();
            modelBuilder.Entity<WebBoardSearchHistory>()
                .MapToStoredProcedures();
            modelBuilder.Entity<WebNotice>()
                .MapToStoredProcedures();
            modelBuilder.Entity<WebNoticeFile>()
                .MapToStoredProcedures();
            modelBuilder.Entity<WebNoticeSearchHistory>()
                .MapToStoredProcedures();
        }
    }
}
