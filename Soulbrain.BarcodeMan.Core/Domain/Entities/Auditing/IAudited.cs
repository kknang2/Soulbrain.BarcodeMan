namespace Soulbrain.BarcodeMan.Domain.Entities.Auditing
{
    public interface IAudited : ICreateAudited, IHasCreateDate, IModifyAudited, IHasModifyDate
    {
    }
}
