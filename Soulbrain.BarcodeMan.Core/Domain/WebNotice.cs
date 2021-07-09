using Soulbrain.BarcodeMan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soulbrain.BarcodeMan.Domain
{
    [Table("SYSWebNotice", Schema = "QRP")]
    public class WebNotice : EntityAudited
    {
        //[Index("PK__SYSWebNotice__276FAA0A", IsClustered = true, IsUnique = true, Order = 1)]
        [Key, Column(Order = 1)]
        [Required]
        [StringLength(MaxPlantCodeLen)]
        public string PlantCode { get; set; }

        //[Index("PK__SYSWebNotice__276FAA0A", IsClustered = true, IsUnique = true, Order = 2)]
        [Key, Column(Order = 2)]
        [Required]
        [StringLength(MaxDocCodeLen)]
        public string DocCode { get; set; }

        [StringLength(MaxTitleKorLen)]
        public string TitleKor { get; set; }

        [StringLength(MaxTitleEngLen)]
        public string TitleEng { get; set; }

        [StringLength(MaxPersonIDLen)]
        public string WriteID { get; set; }

        [StringLength(MaxDateLen)]
        public string WriteDate { get; set; }

        [StringLength(MaxNoticeTypeLen)]
        public string NoticeType { get; set; }

        [StringLength(MaxCompleteFlag)]
        public string CompleteFlag { get; set; }

        [StringLength(MaxContentsKorLen)]
        public string ContentsKor { get; set; }

        [StringLength(MaxContentsEngLen)]
        public string ContentsEng { get; set; }

        [ForeignKey("PlantCode, DocCode")]
        public virtual ICollection<WebNoticeFile> Attachments { get; set; }

        [ForeignKey("PlantCode, DocCode")]
        public virtual ICollection<WebNoticeSearchHistory> SearchHistories { get; set; }
    }
}
