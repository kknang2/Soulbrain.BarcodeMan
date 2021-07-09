using Soulbrain.BarcodeMan.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soulbrain.BarcodeMan.Domain
{
    [Table("MASProductVendor", Schema = "QRP")]
    public class ProductVendor : EntityAudited
    {
        //[Index("PK_MASProductVendor", IsClustered = true, IsUnique = true, Order = 1)]
        [Key, Column(Order = 1)]
        [Required]
        [StringLength(MaxPlantCodeLen)]
        public string PlantCode { get; set; }

        //[Index("PK_MASProductVendor", IsClustered = true, IsUnique = true, Order = 2)]
        [Key, Column(Order = 2)]
        [Required]
        [StringLength(MaxProductCodeLen)]
        public string ProductCode { get; set; }

        //[Index("PK_MASProductVendor", IsClustered = true, IsUnique = true, Order = 3)]
        [Key, Column(Order = 3)]
        [Required]
        public int Seq { get; set; }

        [StringLength(MaxVendorCodeLen)]
        public string PrdVendorCode { get; set; }

        [StringLength(MaxVendorCodeLen)]
        public string SupVendorCode { get; set; }

        //15,5
        public decimal? PackingQty { get; set; }

        [StringLength(MaxUnitCodeLen)]
        public string PackingUnitCode { get; set; }

        [StringLength(MaxEtcDescLen)]
        public string EtcDesc { get; set; }

        //[ForeignKey("ProductCode")]
        //public virtual ICollection<Product> Products { get; set; }

        //[ForeignKey("VendorCode")]
        //public virtual ICollection<Vendor> Vendors { get; set; }
    }
}
