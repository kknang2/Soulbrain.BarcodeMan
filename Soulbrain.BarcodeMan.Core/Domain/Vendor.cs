using Soulbrain.BarcodeMan.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soulbrain.BarcodeMan.Domain
{
    [Table("MASVendor", Schema = "QRP")]
    public class Vendor : EntityAudited, IPassivable
    {
        //[Index("PK_MASVendor_VendorCode", IsClustered = true, IsUnique = true)]
        [Key]
        [Required]
        [StringLength(MaxVendorCodeLen)]
        public string VendorCode { get; set; }

        [StringLength(MaxVendorNameLen)]
        public string VendorName { get; set; }

        [StringLength(MaxVendorNameChLen)]
        public string VendorNameCh { get; set; }

        [StringLength(MaxVendorNameEnLen)]
        public string VendorNameEn { get; set; }

        [StringLength(MaxRegNoLen)]
        public string RegNo { get; set; }

        [StringLength(MaxBossNameLen)]
        public string BossName { get; set; }

        [StringLength(MaxTelLen)]
        public string Tel { get; set; }

        [StringLength(MaxFaxLen)]
        public string Fax { get; set; }

        [StringLength(MaxAddressLen)]
        public string Address { get; set; }

        [StringLength(MaxUseFlagLen)]
        public string UseFlag { get; set; }

        [ForeignKey("VendorCode")]
        public virtual ICollection<VendorP> VendorPs { get; set; }

        [ForeignKey("PrdVendorCode")]
        public virtual ICollection<ProductVendor> ProductVendors { get; set; }
    }
}
