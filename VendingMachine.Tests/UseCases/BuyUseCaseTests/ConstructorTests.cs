using System;
using System.Collections.Generic;
using DataAccess.Repositories.Interfaces;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.Payment.Interfaces;
using iQuest.VendingMachine.UseCases.UseCaseList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace VendingMachine.Tests.UseCases.BuyUseCaseTests
{
    [TestClass]
    public class ConstructorTests
    {
        private Mock<IProductRepository> productRepo;
        private Mock<IBuyView> buyView;
        private List<IPaymentAlgorithm> paymentAlgorithms;
        private Mock<ISoldProductRepository> soldProductRepo;
        private PaymentUseCase paymentUseCase;

        [TestInitialize]
        public void TestSetup()
        {
            productRepo = new Mock<IProductRepository>();
            buyView = new Mock<IBuyView>();
            soldProductRepo = new Mock<ISoldProductRepository>();
            paymentAlgorithms = new List<IPaymentAlgorithm>();
            paymentUseCase = new PaymentUseCase(paymentAlgorithms, buyView.Object);
        }

        [TestMethod]
        public void HavingANullProductRepository_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new BuysUseCase(null, buyView.Object, paymentUseCase, soldProductRepo.Object);
            });
        }

        [TestMethod]
        public void HavingANullBuyView_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new BuysUseCase(productRepo.Object, null, paymentUseCase, soldProductRepo.Object);
            });
        }

        [TestMethod]
        public void HavingANullPaymentUseCase_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new BuysUseCase(productRepo.Object, buyView.Object, null, soldProductRepo.Object);
            });
        }

        [TestMethod]
        public void HavingANullReportsSerializer_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new BuysUseCase(productRepo.Object, buyView.Object, paymentUseCase, null);
            });
        }

        [TestMethod]
        public void HappyFlow_WhenInitializingTheUseCase_NoExceptionIsThrown()
        {
            Assert.IsNotNull(new BuysUseCase(productRepo.Object, buyView.Object, paymentUseCase, soldProductRepo.Object));
        }
    }
}
