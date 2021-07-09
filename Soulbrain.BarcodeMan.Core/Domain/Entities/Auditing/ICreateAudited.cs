namespace Soulbrain.BarcodeMan.Domain.Entities.Auditing
{
    public interface ICreateAudited : IHasCreateDate
    {
        //
        // Summary:
        //     IP address of the creator user of this entity.
        string CreateIP { get; set; }

        //
        // Summary:
        //     ID of the creator user of this entity.
        string CreateID { get; set; }
    }
}
