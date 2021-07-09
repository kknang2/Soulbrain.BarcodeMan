using Soulbrain.BarcodeMan.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Soulbrain.BarcodeMan.Dtos.WebBarCode
{
    public class WebBarCodeInput
    {
        [Required]
        [StringLength(EntityBase.MaxPlantCodeLen)]
        public string PlantCode { get; set; }

        [Required]
        [StringLength(EntityBase.MaxDocCodeLen)]
        public string DocCode { get; set; }

        [StringLength(EntityBase.MaxProductCodeLen)]
        public string ProductCode { get; set; }

        public decimal? SupplyQty { get; set; }

        [StringLength(EntityBase.MaxUnitCodeLen)]
        public string PackingUnitCode { get; set; }

        [StringLength(EntityBase.MaxLotNoLen)]
        public string LotNo { get; set; }

        [StringLength(EntityBase.MaxDateLen)]
        public string ProductDate { get; set; }

        [MaxLength(EntityBase.MaxExpDateCodeLen)]
        public string ExpDateCode { get; set; }

        [StringLength(EntityBase.MaxDateLen)]
        public string SupplyDate { get; set; }

        public int? PrintQty { get; set; }

        public DateTime? PrintDatetime { get; set; }

        [StringLength(EntityBase.MaxPrintTypeLen)]
        public string PrintType { get; set; }

    }
}
