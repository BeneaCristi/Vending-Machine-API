using System;
using iQuest.VendingMachine.Services.Authentication;
using iQuest.VendingMachine.UseCases.Reports.UseCaseList;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.UseCases.Interfaces;

namespace iQuest.VendingMachine.PresentationLayer.Commands.Reports
{
    internal class SalesReportCommand : ICommand
    {
        private readonly IUseCaseFactory useCaseFactory;
        private readonly IAuthenticationService authenticationService;

        public string Name => "Sales Report";

        public string Description => "   - View and Save sales report (all the processed sales) for a specifictime range";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public SalesReportCommand(IAuthenticationService authenticationService, IUseCaseFactory useCaseFactory)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        }

        public void Execute()
        {
            useCaseFactory.Create<SalesReportUseCase>().Execute();
        }
    }
}
