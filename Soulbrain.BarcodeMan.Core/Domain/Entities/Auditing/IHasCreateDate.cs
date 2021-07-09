using System;

namespace Soulbrain.BarcodeMan.Domain.Entities.Auditing
{
    public interface IHasCreateDate
    {
        //
        // Summary:
        //     Creation time of this entity.
        DateTime? CreateDate { get; set; }
    }
}
