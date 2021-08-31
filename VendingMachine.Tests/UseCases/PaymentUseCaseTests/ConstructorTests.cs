using System;
using System.Collections.Generic;
using iQuest.VendingMachine.UseCases.UseCaseList;
using iQuest.VendingMachine.Payment.Interfaces;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace VendingMachine.Tests.UseCases.PaymentUseCaseTests
{
    [TestClass]
    public class ConstructorTests
    {
        private List<IPaymentAlgorithm> paymentAlgorithms;
        private Mock<IBuyView> buyView;

        [TestInitialize]
        public void TestSetup()
        {
            paymentAlgorithms = new List<IPaymentAlgorithm>();
            buyView = new Mock<IBuyView>();
        }

        [TestMethod]
        public void HavingANullListOfPaymentAlgorithms_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new PaymentUseCase(null, buyView.Object);
            });
        }

        [TestMethod]
        public void HavingANullBuyView_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new PaymentUseCase(paymentAlgorithms, null);
            });
        }

        [TestMethod]
        public void HappyFlowpRroductRepositoryAndShelfView_WhenInitializingTheUseCase_NoExceptionIsThrown()
        {
            Assert.IsNotNull(new PaymentUseCase(paymentAlgorithms, buyView.Object));
        }
    }
}
