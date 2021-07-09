using Soulbrain.BarcodeMan.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;

namespace Soulbrain.BarcodeMan.Domain.Entities
{
    public abstract class EntityAudited : EntityBase, IAudited
    {
        [StringLength(MaxIPAddressLen)]
        public virtual string CreateIP { get; set; }
        [StringLength(MaxPersonIDLen)]
        public virtual string CreateID { get; set; }
        public virtual DateTime? CreateDate { get; set; }
        [StringLength(MaxIPAddressLen)]
        public virtual string ModifyIP { get; set; }
        [StringLength(MaxPersonIDLen)]
        public virtual string ModifyID { get; set; }
        public virtual DateTime? ModifyDate { get; set; }
    }
}
