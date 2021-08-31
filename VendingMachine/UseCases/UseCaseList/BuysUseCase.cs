using System;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.UseCases.Interfaces;
using DataAccess.Repositories.Interfaces;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VendingMachine.Tests")]


namespace iQuest.VendingMachine.UseCases.UseCaseList
{
    internal class BuysUseCase : IUseCase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IProductRepository productRepo;
        private readonly IBuyView buyView;
        private readonly IPaymentUseCase paymentUseCase;
        private readonly ISoldProductRepository soldLiteDb;

        public BuysUseCase(IProductRepository productRepo, IBuyView buyView, IPaymentUseCase paymentUseCase,  ISoldProductRepository soldLiteDb)
        {
            this.productRepo = productRepo ?? throw new ArgumentNullException(nameof(productRepo));
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.paymentUseCase = paymentUseCase ?? throw new ArgumentNullException(nameof(paymentUseCase));
            this.soldLiteDb = soldLiteDb ?? throw new ArgumentNullException(nameof(soldLiteDb));
        }

        public void Execute()
        {
            int id = buyView.RequestId();
            float price = (float)productRepo.GetById(id).Price;
            string name = productRepo.GetById(id).Name;
            

            if (paymentUseCase.Execute(price, name))
            {
                soldLiteDb.Add(DateTime.Now, productRepo.GetById(id).Name, (float)productRepo.GetById(id).Price, paymentUseCase.PaymentMethod.Name);
                productRepo.DecrementStock(id);
                buyView.DispenseProduct(productRepo.GetById(id).Name);
            }

            log.Info($"User BOUGHT a {name}\n");
        }
    }
}
