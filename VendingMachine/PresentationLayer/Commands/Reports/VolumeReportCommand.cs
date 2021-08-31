using System;
using iQuest.VendingMachine.Services.Authentication;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.UseCases.Interfaces;
using iQuest.VendingMachine.UseCases.Reports.UseCaseList;

namespace iQuest.VendingMachine.PresentationLayer.Commands.Reports
{
    internal class VolumeReportCommand : ICommand
    {
        private readonly IUseCaseFactory useCaseFactory;
        private readonly IAuthenticationService authenticationService;

        public string Name => "Volume Report";

        public string Description => "  - View the Volume report (product volume is the total sales of a product) for a specific time range";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public VolumeReportCommand(IAuthenticationService authenticationService, IUseCaseFactory useCaseFactory)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        }

        public void Execute()
        {
            useCaseFactory.Create<VolumeReportUseCase>().Execute();
        }
    }
}
