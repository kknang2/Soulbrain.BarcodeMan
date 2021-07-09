namespace Soulbrain.BarcodeMan.Authenticate
{
    public interface IAuthProvider
    {
        User User { get; }

        bool IsGuest { get; }

        bool CheckPasswordValid(string password);

        bool ChangePassword(string password);

        bool AttemptLogin(string userId, string password, bool rememberMe);

        void Logout();
    }
}
