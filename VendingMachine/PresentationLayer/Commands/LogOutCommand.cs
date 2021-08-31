using System;
using iQuest.VendingMachine.Services.Authentication;
using iQuest.VendingMachine.UseCases.UseCaseList;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.UseCases.Interfaces;

namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    internal class LogOutCommand : ICommand
    {
        private readonly IUseCaseFactory useCaseFactory;
        private readonly IAuthenticationService authenticationService;

        public string Name => "Logout";

        public string Description => " - Restrict access to administration section";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public LogOutCommand(IUseCaseFactory useCaseFactory , IAuthenticationService authenticationService)
        {
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public void Execute()
        {
            useCaseFactory.Create<LogoutUseCase>().Execute();
        }
    }
}
