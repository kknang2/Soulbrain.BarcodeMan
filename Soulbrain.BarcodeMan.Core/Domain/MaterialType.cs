using Soulbrain.BarcodeMan.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soulbrain.BarcodeMan.Domain
{
    [Table("MASMaterialType", Schema = "QRP")]
    public class MaterialType : EntityAudited, IPassivable
    {
        //[Index("PK_MASMaterialType_PlantCode_MaterialTypeCode", IsClustered = true, IsUnique = true, Order = 1)]
        [Key, Column(Order = 1)]
        [Required]
        [StringLength(MaxPlantCodeLen)]
        public string PlantCode { get; set; }

        //[Index("PK_MASMaterialType_PlantCode_MaterialTypeCode", IsClustered = true, IsUnique = true, Order = 2)]
        [Key, Column(Order = 2)]
        [Required]
        [StringLength(MaxMaterialTypeCodeLen)]
        public string MaterialTypeCode { get; set; }

        [StringLength(MaxMaterialTypeNameLen)]
        public string MaterialTypeName { get; set; }

        [StringLength(MaxMaterialTypeNameLen)]
        public string MaterialTypeNameCh { get; set; }

        [StringLength(MaxMaterialTypeNameLen)]
        public string MaterialTypeNameEn { get; set; }

        [StringLength(MaxUseFlagLen)]
        public string UseFlag { get; set; }

        [ForeignKey("PlantCode, MaterialTypeCode")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
