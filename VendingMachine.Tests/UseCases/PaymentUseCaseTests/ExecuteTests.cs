using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.UseCases.UseCaseList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using iQuest.VendingMachine.Payment.Interfaces;
using iQuest.VendingMachine.Payment.Services;
using iQuest.VendingMachine.Exceptions;
using System.Collections.Generic;
using Moq;

namespace VendingMachine.Tests.UseCases.PaymentUseCaseTests
{
    [TestClass]
    public class ExecuteTests
    {
        private Mock<IBuyView> buyView;
        private List<IPaymentAlgorithm> paymentAlgorithms;
        private Mock<IPaymentAlgorithm> paymentAlgorithm;
        private PaymentUseCase paymentUseCase;

        [TestInitialize]
        public void TestSetup()
        {
            buyView = new Mock<IBuyView>();
            paymentAlgorithm = new Mock<IPaymentAlgorithm>();
            paymentAlgorithms = new List<IPaymentAlgorithm>
            {
               paymentAlgorithm.Object
            };

            paymentUseCase = new PaymentUseCase(paymentAlgorithms, buyView.Object);
        }


        [TestMethod]
        public void HavingAPaymentUseCaseInstance_WhenAskForPaymentMethodReturnsNot1Or2_ThenCancelExceptionIsThrown()
        {
            //arragne
            buyView
                .Setup(x => x.AskForPaymentMethod(It.IsAny<IEnumerable<PaymentMethod>>()))
                .Returns(3);

            //act
            
            //assert
            Assert.ThrowsException<CancelledPaymentException>(() =>
            {
                paymentUseCase.Execute(It.IsAny<float>(), It.IsAny<string>());
            });
        }
    }
}