using Soulbrain.BarcodeMan.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soulbrain.BarcodeMan.Domain
{
    [Table("MASMaterialGroup", Schema = "QRP")]
    public class MaterialGroup : EntityAudited, IPassivable
    {
        //[Index("PK_MASMaterialGroup_PlantCode_MaterialGroupCode", IsClustered = true, IsUnique = true, Order = 1)]
        [Key, Column(Order = 1)]
        [Required]
        [StringLength(MaxPlantCodeLen)]
        public string PlantCode { get; set; }

        //[Index("PK_MASMaterialGroup_PlantCode_MaterialGroupCode", IsClustered = true, IsUnique = true, Order = 2)]
        [Key, Column(Order = 2)]
        [Required]
        [StringLength(MaxMaterialGroupCodeLen)]
        public string MaterialGroupCode { get; set; }

        [StringLength(MaxMaterialGroupNameLen)]
        public string MaterialGroupName { get; set; }

        [StringLength(MaxMaterialGroupNameChLen)]
        public string MaterialGroupNameCh { get; set; }

        [StringLength(MaxMaterialGroupNameEnLen)]
        public string MaterialGroupNameEn { get; set; }

        [StringLength(MaxUseFlagLen)]
        public string UseFlag { get; set; }

        [ForeignKey("PlantCode, MaterialGroupCode")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
