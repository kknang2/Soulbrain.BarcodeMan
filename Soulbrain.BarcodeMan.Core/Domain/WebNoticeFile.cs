using Soulbrain.BarcodeMan.Domain.Entities;
using Soulbrain.BarcodeMan.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soulbrain.BarcodeMan.Domain
{
    [Table("SYSWebNoticeFile", Schema = "QRP")]
    public class WebNoticeFile : EntityAudited
    {
        //[Index("PK__SYSWebNoticeFile__276FAA0A", IsClustered = true, IsUnique = true, Order = 1)]
        [Key, Column(Order = 1)]
        [Required]
        [StringLength(MaxPlantCodeLen)]
        public string PlantCode { get; set; }

        //[Index("PK__SYSWebNoticeFile__276FAA0A", IsClustered = true, IsUnique = true, Order = 2)]
        [Key, Column(Order = 2)]
        [Required]
        [StringLength(MaxDocCodeLen)]
        public string DocCode { get; set; }

        //[Index("PK__SYSWebNoticeFile__276FAA0A", IsClustered = true, IsUnique = true, Order = 3)]
        [Key, Column(Order = 3)]
        [Required]
        public int Seq { get; set; }

        [StringLength(MaxEtcDescKorLen)]
        public string EtcDescKor { get; set; }

        [StringLength(MaxEtcDescEngLen)]
        public string EtcDescEng { get; set; }

        [StringLength(MaxFileNameLen)]
        public string FileName { get; set; }

        [StringLength(MaxFileGUIDLen)]
        public string FileGUID { get; set; }

        [ForeignKey("PlantCode, DocCode")]
        public virtual WebNotice WebNotice { get; set; }

        public string EtcDesc
        {
            get
            {
                if (CultureHelper.GetCurrentNeutralCulture().Equals("en") &&
                    !string.IsNullOrEmpty(EtcDescEng))
                {
                    return EtcDescEng;
                }

                return EtcDescKor;
            }
        }
    }
}
