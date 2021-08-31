using VendingMachineDomain.Exceptions;

namespace iQuest.VendingMachine.Services.Authentication
{
    internal class AuthenticationService : IAuthenticationService
    {
        public bool IsUserAuthenticated { get; private set; }

        public void Login(string password)
        {
            if (password == "iquest")
                IsUserAuthenticated = true;
            else
                throw new InvalidPasswordException();
        }

        public void Logout()
        {
            IsUserAuthenticated = false;
        }
    }
}