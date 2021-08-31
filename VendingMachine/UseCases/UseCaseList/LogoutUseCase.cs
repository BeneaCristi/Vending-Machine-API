using System;
using iQuest.VendingMachine.Services.Authentication;
using System.Runtime.CompilerServices;
using iQuest.VendingMachine.UseCases.Interfaces;

[assembly: InternalsVisibleTo("VendingMachine.Tests")]

namespace iQuest.VendingMachine.UseCases.UseCaseList
{
    internal class LogoutUseCase : IUseCase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IAuthenticationService authenticationService;

        public LogoutUseCase(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public void Execute()
        {
            authenticationService.Logout();

            log.Info("User LOGGED OUT\n");
        }
    }
}