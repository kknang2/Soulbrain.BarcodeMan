using Soulbrain.BarcodeMan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soulbrain.BarcodeMan.Domain
{
    [Table("SYSWebBoard", Schema = "QRP")]
    public class WebBoard : EntityAudited
    {
        //[Index("PK__SYSWebBoard__276FAA0A", IsClustered = true, IsUnique = true, Order = 1)]
        [Key, Column(Order = 1)]
        [Required]
        [StringLength(MaxPlantCodeLen)]
        public string PlantCode { get; set; }

        //[Index("PK__SYSWebBoard__276FAA0A", IsClustered = true, IsUnique = true, Order = 2)]
        [Key, Column(Order = 2)]
        [Required]
        [StringLength(MaxDocCodeLen)]
        public string DocCode { get; set; }

        [StringLength(MaxVendorCodeLen)]
        public string VendorCode { get; set; }

        [StringLength(MaxTitleKorLen)]
        public string TitleKor { get; set; }

        [StringLength(MaxTitleEngLen)]
        public string TitleEng { get; set; }

        [StringLength(MaxPersonIDLen)]
        public string WriteID { get; set; }

        [StringLength(MaxDateLen)]
        public string WriteDate { get; set; }

        [StringLength(MaxBoardTypeLen)]
        public string BoardType { get; set; }

        [StringLength(MaxContentsKorLen)]
        public string ContentsKor { get; set; }

        [StringLength(MaxContentsEngLen)]
        public string ContentsEng { get; set; }

        [ForeignKey("PlantCode, DocCode")]
        public virtual ICollection<WebBoardComment> Comments { get; set; }

        [ForeignKey("PlantCode, DocCode")]
        public virtual ICollection<WebBoardFile> Attachments { get; set; }

        [ForeignKey("PlantCode, DocCode")]
        public virtual ICollection<WebBoardSearchHistory> SearchHistories { get; set; }
    }
}
