using Soulbrain.BarcodeMan.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soulbrain.BarcodeMan.Domain
{
    [Table("MASVendorP", Schema = "QRP")]
    public class VendorP : EntityAudited, IPassivable
    {
        //[Index("PK_MASVendorP_VendorCode_Seq", IsClustered = true, IsUnique = true, Order = 1)]
        [Key, Column(Order = 1)]
        [Required]
        [StringLength(MaxVendorCodeLen)]
        public string VendorCode { get; set; }

        //[Index("PK_MASVendorP_VendorCode_Seq", IsClustered = true, IsUnique = true, Order = 2)]
        [Key, Column(Order = 2)]
        [Required]
        public int Seq { get; set; }

        [StringLength(MaxPersonIDLen)]
        public string PersonID { get; set; }

        [StringLength(MaxPersonPWLen)]
        public string PersonPW { get; set; }

        [StringLength(MaxPersonJobLen)]
        public string PersonJob { get; set; }

        [StringLength(MaxPersonDeptNameLen)]
        public string PersonDeptName { get; set; }

        [StringLength(MaxPersonNameLen)]
        public string PersonName { get; set; }

        [StringLength(MaxPersonPositionLen)]
        public string PersonPosition { get; set; }

        [StringLength(MaxTelLen)]
        public string PersonTel { get; set; }

        [StringLength(MaxPersonHpLen)]
        public string PersonHp { get; set; }

        [DataType(DataType.EmailAddress)]
        public string PersonEMail { get; set; }

        [StringLength(MaxPersonEtcDescLen)]
        public string EtcDesc { get; set; }

        [StringLength(MaxUseFlagLen)]
        public string UseFlag { get; set; }

        [ForeignKey("VendorCode")]
        public virtual Vendor Vendor { get; set; }
    }
}
