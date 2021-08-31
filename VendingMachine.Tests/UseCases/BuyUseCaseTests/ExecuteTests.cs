using System;
using DataAccess.Repositories.Interfaces;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.UseCases.UseCaseList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess.Models;
using iQuest.VendingMachine.Payment.Interfaces;
using System.Collections.Generic;
using Moq;

namespace VendingMachine.Tests.UseCases.BuyUseCaseTests
{
    [TestClass]
    public class ExecuteTests
    {
        private Mock<IProductRepository> productRepo;
        private Mock<IBuyView> buyView;
        private Mock<IPaymentAlgorithm> paymentAlgorithm;
        private List<IPaymentAlgorithm> paymentAlgorithms;
        private Mock<ISoldProductRepository> soldProductRepo;
        private Mock<PaymentUseCase> paymentUseCase;
        private BuysUseCase buyUseCase;

        [TestInitialize]
        public void TestSetup()
        {
            productRepo = new Mock<IProductRepository>();
            buyView = new Mock<IBuyView>();
            soldProductRepo = new Mock<ISoldProductRepository>();
            paymentAlgorithm = new Mock<IPaymentAlgorithm>();
            paymentAlgorithms = new List<IPaymentAlgorithm>
            {
               paymentAlgorithm.Object
            };
            paymentUseCase = new Mock<PaymentUseCase>(paymentAlgorithms, buyView.Object);
            buyUseCase = new BuysUseCase(productRepo.Object, buyView.Object, paymentUseCase.Object, soldProductRepo.Object);
        }

        [TestMethod]
        public void HavingABuyUseCaseInstance_WhenExecuted_ThenUserIsAskedToIntroduceId()
        {
            //arange
            var p = new Product(0, "name", 0f, 0);

            productRepo
               .Setup(x => x.GetById(It.IsAny<int>()))
               .Returns(p);

            //act
            buyUseCase.Execute();

            //assert
            buyView.Verify(x => x.RequestId(), Times.Once);
        }

        [TestMethod]
        public void HavingABuyUseCaseInstance_WhenExecutedSuccessfully_ThenCallDBADD()
        {
            //arrange
            var p = new Product(0, "name", 0f, 0);

            productRepo
               .Setup(x => x.GetById(It.IsAny<int>()))
               .Returns(p);

            paymentUseCase
               .Setup(x => x.Execute(It.IsAny<float>(), It.IsAny<string>()))
               .Returns(true);

            //act
            buyUseCase.Execute();

            //assert
            soldProductRepo.Verify(x => x.Add(It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<float>(), It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void HavingABuyUseCaseInstance_WhenExecutedSuccessfully_ThenStockDecrements()
        {
            //arrange
            var p = new Product(0, "name", 0f, 0);

            productRepo
               .Setup(x => x.GetById(It.IsAny<int>()))
               .Returns(p);

            paymentUseCase
               .Setup(x => x.Execute(It.IsAny<float>(), It.IsAny<string>()))
               .Returns(true);

            //act
            buyUseCase.Execute();

            //assert
            productRepo.Verify(x => x.DecrementStock(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void HavingABuyUseCaseInstance_WhenExecutedSuccessfuly_ThenDispenseProduct()
        {
            //arrange
            var p = new Product(0, "name", 0f, 0);

            productRepo
                  .Setup(x => x.GetById(It.IsAny<int>()))
                  .Returns(p);

            paymentUseCase
              .Setup(x => x.Execute(It.IsAny<float>(), It.IsAny<string>()))
              .Returns(true);

            //act
            buyUseCase.Execute();

            //assert
            buyView.Verify(x => x.DispenseProduct(It.IsAny<string>()), Times.Once);
        }
    }
}