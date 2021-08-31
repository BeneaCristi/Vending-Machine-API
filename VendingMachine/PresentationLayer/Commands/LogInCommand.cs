using System;
using iQuest.VendingMachine.Services.Authentication;
using iQuest.VendingMachine.UseCases.UseCaseList;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.UseCases.Interfaces;

namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    internal class LogInCommand : ICommand
    {
        private readonly IUseCaseFactory useCaseFactory;
        private readonly IAuthenticationService authenticationService;

        public string Name => "Login";

        public string Description => "  - Get access to administration section";

        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        public LogInCommand(IUseCaseFactory useCaseFactory, IAuthenticationService authenticationService)
        {
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public void Execute()
        {
            useCaseFactory.Create<LoginUseCase>().Execute();
        }
    }
}
