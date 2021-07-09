namespace Soulbrain.BarcodeMan.Domain.Entities.Auditing
{
    public interface IModifyAudited : IHasModifyDate
    {
        //
        // Summary:
        //     IP address of the modifier user of this entity.
        string ModifyIP { get; set; }

        //
        // Summary:
        //     ID of the modifier user of this entity.
        string ModifyID { get; set; }
    }
}
