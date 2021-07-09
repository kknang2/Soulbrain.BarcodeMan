using System;

namespace Soulbrain.BarcodeMan.Domain.Entities.Auditing
{
    public interface IHasModifyDate
    {
        //
        // Summary:
        //     Modification time of this entity.
        DateTime? ModifyDate { get; set; }
    }
}
