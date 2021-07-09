using Soulbrain.BarcodeMan.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soulbrain.BarcodeMan.Domain
{
    [Table("SYSWebBarCode", Schema ="QRP")]
    public class WebBarCode : EntityAudited
    {
        //[Index("PK_SYSWebBarCode", IsClustered = true, IsUnique = true, Order = 1)]
        [Key, Column(Order = 1)]
        [Required]
        [StringLength(MaxPlantCodeLen)]
        public string PlantCode { get; set; }

        //[Index("PK_SYSWebBarCode", IsClustered = true, IsUnique = true, Order = 2)]
        [Key, Column(Order = 2)]
        [Required]
        [StringLength(MaxDocCodeLen)]
        public string DocCode { get; set; }

        [StringLength(MaxProductCodeLen)]
        public string ProductCode { get; set; }

        // 15,5
        public decimal? SupplyQty { get; set; }

        [StringLength(MaxUnitCodeLen)]
        public string PackingUnitCode { get; set; }

        [StringLength(MaxLotNoLen)]
        public string LotNo { get; set; }

        [StringLength(MaxDateLen)]
        public string ProductDate { get; set; }

        [Column("ExpiryDate")]
        [MaxLength(MaxExpDateCodeLen)]
        public string ExpDateCode { get; set; }

        [StringLength(MaxDateLen)]
        public string SupplyDate { get; set; }

        public int? PrintQty { get; set; }

        public DateTime? PrintDatetime { get; set; }

        [StringLength(MaxPrintTypeLen)]
        public string PrintType { get; set; }

        [ForeignKey("PlantCode, ProductCode")]
        public virtual Product Product { get; set; }
    }
}
