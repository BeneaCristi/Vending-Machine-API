using System;
using iQuest.VendingMachine.Services.Authentication;
using iQuest.VendingMachine.UseCases.UseCaseList;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.UseCases.Interfaces;

namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    internal class ManageMachineCommand : ICommand
    {
        private readonly IUseCaseFactory useCaseFactory;
        private readonly IAuthenticationService authenticationService;

        public string Name => "Manage Machine";

        public string Description => " - Manages the products of the Vending Machine\n";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public ManageMachineCommand(IUseCaseFactory useCaseFactory, IAuthenticationService authenticationService)
        {
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public void Execute()
        {
            useCaseFactory.Create<ManageMachineUseCase>().Execute();
        }
    }
}
