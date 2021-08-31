using System;
using iQuest.VendingMachine.Services.Authentication;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.UseCases.Interfaces;
using iQuest.VendingMachine.UseCases.Reports.UseCaseList;

namespace iQuest.VendingMachine.PresentationLayer.Commands.Reports
{
    internal class StockReportCommand : ICommand
    {
        private readonly IUseCaseFactory useCaseFactory;
        private readonly IAuthenticationService authenticationService;

        public string Name => "Stock Report";

        public string Description => "   - See and store the stock report";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public StockReportCommand(IAuthenticationService authenticationService, IUseCaseFactory useCaseFactory)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        }

        public void Execute()
        {
            useCaseFactory.Create<StockReportUseCase>().Execute();
        }
    }
}
