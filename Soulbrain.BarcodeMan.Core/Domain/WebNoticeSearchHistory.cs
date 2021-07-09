﻿using Soulbrain.BarcodeMan.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soulbrain.BarcodeMan.Domain
{
    [Table("SYSWebNoticeSearchHistory", Schema ="QRP")]
    public class WebNoticeSearchHistory : EntityAudited
    {
        //[Index("PK_SYSWebNoticeSearchHistory", IsClustered = true, IsUnique = true, Order = 1)]
        [Key, Column(Order = 1)]
        [Required]
        [StringLength(MaxPlantCodeLen)]
        public string PlantCode { get; set; }

        //[Index("PK_SYSWebNoticeSearchHistory", IsClustered = true, IsUnique = true, Order = 2)]
        [Key, Column(Order = 2)]
        [Required]
        [StringLength(MaxDocCodeLen)]
        public string DocCode { get; set; }

        //[Index("PK_SYSWebNoticeSearchHistory", IsClustered = true, IsUnique = true, Order = 3)]
        [Key, Column(Order = 3)]
        [Required]
        public int Seq { get; set; }

        [StringLength(MaxVendorCodeLen)]
        public string VendorCode { get; set; }

        [StringLength(MaxPersonIDLen)]
        public string PersonID { get; set; }

        public DateTime? SearchDatetime { get; set; }

        [ForeignKey("PlantCode, DocCode")]
        public virtual WebNotice WebNotice { get; set; }
    }
}
