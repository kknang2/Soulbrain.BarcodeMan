using Soulbrain.BarcodeMan.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soulbrain.BarcodeMan.Domain
{
    [Table("SYSWebBoardComment", Schema = "QRP")]
    public class WebBoardComment : EntityAudited
    {
        //[Index("PK_SYSWebBoardComment", IsClustered = true, IsUnique = true, Order = 1)]
        [Key, Column(Order = 1)]
        [Required]
        [StringLength(MaxPlantCodeLen)]
        public string PlantCode { get; set; }

        //[Index("PK_SYSWebBoardComment", IsClustered = true, IsUnique = true, Order = 2)]
        [Key, Column(Order = 2)]
        [Required]
        [StringLength(MaxDocCodeLen)]
        public string DocCode { get; set; }

        //[Index("PK_SYSWebBoardComment", IsClustered = true, IsUnique = true, Order = 3)]
        [Key, Column(Order = 3)]
        [Required]
        public int Seq { get; set; }

        [StringLength(MaxCommentLen)]
        public string Comment { get; set; }

        [StringLength(MaxPersonIDLen)]
        public string WriteID { get; set; }

        public DateTime? WriteDatetime { get; set; }

        [ForeignKey("PlantCode, DocCode")]
        public virtual WebBoard WebBoard { get; set; }
    }
}
