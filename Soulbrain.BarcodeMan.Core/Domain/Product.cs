using Soulbrain.BarcodeMan.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soulbrain.BarcodeMan.Domain
{
    [Table("MASProduct", Schema = "QRP")]
    public class Product : EntityAudited, IPassivable
    {
        //[Index("PK_MASProduct_PlantCode_ProductCode", IsClustered = true, IsUnique = true, Order = 1)]
        [Key, Column(Order = 1)]
        [Required]
        [StringLength(MaxPlantCodeLen)]
        public string PlantCode { get; set; }

        //[Index("PK_MASProduct_PlantCode_ProductCode", IsClustered = true, IsUnique = true, Order = 2)]
        [Key, Column(Order = 2)]
        [Required]
        [StringLength(MaxProductCodeLen)]
        public string ProductCode { get; set; }

        [StringLength(MaxProductNameLen)]
        public string ProductName { get; set; }

        [StringLength(MaxProductNameChLen)]
        public string ProductNameCh { get; set; }

        [StringLength(MaxProductNameEnLen)]
        public string ProductNameEn { get; set; }

        [StringLength(MaterialGroup.MaxMaterialGroupCodeLen)]
        public string MaterialGroupCode { get; set; }

        [StringLength(MaterialType.MaxMaterialTypeCodeLen)]
        public string MaterialTypeCode { get; set; }

        [StringLength(MaxSpecLen)]
        public string Spec { get; set; }

        [StringLength(MaxDrawingNoLen)]
        public string DrawingNo { get; set; }

        [StringLength(MaxCarTypeCodeLen)]
        public string CarTypeCode { get; set; }

        [StringLength(MaxSecondNoLen)]
        public string SecondNo { get; set; }

        [StringLength(MaxMoldingEquipCodeLen)]
        public string MoldingEquipCode { get; set; }

        [StringLength(MaxMeltingFurnaceCodeLen)]
        public string MeltingFurnaceCode { get; set; }

        // 10,2
        public decimal? ProductWeight { get; set; }

        public int? Cavity { get; set; }

        [StringLength(MaxProductQualityLen)]
        public string ProductQuality { get; set; }

        // 15,4
        public decimal? NetPrice { get; set; }

        [StringLength(MaxCoreTypeLen)]
        public string CoreType { get; set; }

        // 10,2
        public decimal? RealProductWeight { get; set; }

        [StringLength(MaxMarketTypeLen)]
        public string MarketType { get; set; }

        // 10, 2
        public decimal? RecoverRate { get; set; }

        // 10, 2
        public decimal? PourWeight { get; set; }

        [Column("attachCount1")]
        public int? AttachCount1 { get; set; }

        [Column("attachCount2")]
        public int? AttachCount2 { get; set; }

        [StringLength(MaxUnitCodeLen)]
        public string BaseUnitCode { get; set; }

        // 20,5
        public decimal? WorkLotSize { get; set; }

        [StringLength(MaxInspectFlagLen)]
        public string InspectFlag { get; set; }

        [StringLength(MaxInspectFaultInventoryCodeLen)]
        public string InspectFaultInventoryCode { get; set; }

        [StringLength(MaxAvailInventoryCodeLen)]
        public string AvailInventoryCode { get; set; }

        [StringLength(MaxWorkInStandbyInventoryCodeLen)]
        public string WorkInStandbyInventoryCode { get; set; }

        // 20,5
        public decimal? SizePerPack { get; set; }

        [StringLength(MaxUnitCodeLen)]
        public string PackUnitCode { get; set; }

        [StringLength(MaxSerialUseFlagLen)]
        public string SerialUseFlag { get; set; }

        public decimal? ProdQtyPerProduct { get; set; }

        [StringLength(MaxInspectStandbyInventoryCodeLen)]
        public string InspectStandbyInventoryCode { get; set; }

        [StringLength(MaxProdTypeCodeLen)]
        public string ProdTypeCode { get; set; }

        [StringLength(MaxUseFlagLen)]
        public string UseFlag { get; set; }

        [ForeignKey("PlantCode, MaterialGroupCode")]
        public virtual MaterialGroup MaterialGroup { get; set; }

        [ForeignKey("PlantCode, MaterialTypeCode")]
        public virtual MaterialType MaterialType { get; set; }

        [ForeignKey("PlantCode, ProductCode")]
        public virtual ICollection<ProductVendor> ProductVendors { get; set; }

        [ForeignKey("PlantCode, ProductCode")]
        public virtual ICollection<WebBarCode> WebBarcodes { get; set; }
    }
}
