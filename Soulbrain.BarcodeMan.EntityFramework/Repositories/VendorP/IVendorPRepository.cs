using Soulbrain.BarcodeMan.Authenticate;

namespace Soulbrain.BarcodeMan.Repositories
{
    public interface IVendorPRepository
    {
        User GetUserByCredentials(string personID, string password);

        User GetUserByPersonID(string personID);

        bool ChangePassword(string personID, string password);
    }
}
