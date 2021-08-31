using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using System;
using System.Runtime.CompilerServices;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.UseCases.Interfaces;

[assembly: InternalsVisibleTo("VendingMachine.Tests")]

namespace iQuest.VendingMachine.UseCases.UseCaseList
{
    internal class LookUseCase : IUseCase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IProductRepository productRepo;
        private readonly IShelfView shelfView;

        public LookUseCase(IProductRepository productRepo, IShelfView shelfView)
        {
            this.productRepo = productRepo ?? throw new ArgumentNullException(nameof(productRepo));
            this.shelfView = shelfView ?? throw new ArgumentNullException(nameof(shelfView));
        }

        public void Execute()
        {
            shelfView.DisplayProducts(productRepo.GetAll());

            log.Info("User LOOKED in the machine\n");
        }
    }
}
