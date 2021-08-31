using System;
using DataAccess.Repositories.Interfaces;
using System.Linq;
using iQuest.VendingMachine.Services.Authentication;
using iQuest.VendingMachine.UseCases.UseCaseList;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.UseCases.Interfaces;
using iQuest.VendingMachine.PresentationLayer.DisplayConfiguration;

namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    internal class BuyCommand : DisplayBase , ICommand
    {
        private readonly IUseCaseFactory useCaseFactory;
        private readonly IProductRepository productRepo;
        private readonly IAuthenticationService authenticationService;

        public string Name => "Buy";

        public string Description => "    - Buy an item";

        public bool CanExecute => productRepo.GetAll().Any() && !authenticationService.IsUserAuthenticated;

        public BuyCommand(IUseCaseFactory useCaseFactory, IProductRepository productRepo, IAuthenticationService authenticationService)
        {
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
            this.productRepo = productRepo ?? throw new ArgumentNullException(nameof(productRepo));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public void Execute()
        {
            useCaseFactory.Create<BuysUseCase>().Execute();
        }
    }
}
