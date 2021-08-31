using System;
using iQuest.VendingMachine.Services.Authentication;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.UseCases.Interfaces;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VendingMachine.Tests")]

namespace iQuest.VendingMachine.UseCases.UseCaseList
{
    internal class LoginUseCase : IUseCase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IAuthenticationService authenticationService;
        private readonly ILoginView loginView;

        public LoginUseCase(IAuthenticationService authenticationService, ILoginView loginView)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.loginView = loginView ?? throw new ArgumentNullException(nameof(loginView));
        }

        public void Execute()
        {
            string password = loginView.AskForPassword();
            authenticationService.Login(password);

            log.Info("User LOGGED IN\n");
        }
    }
}