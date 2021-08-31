using System;
using iQuest.VendingMachine.Services.Authentication;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.UseCases.UseCaseList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace VendingMachine.Tests.UseCases.LoginUseCaseTests
{
    [TestClass]
    public class ConstructorTests
    {
        private Mock<IAuthenticationService> authenticationService;
        private Mock<ILoginView> loginView;

        [TestInitialize]
        public void TestSetup()
        {
            authenticationService = new Mock<IAuthenticationService>();
            loginView = new Mock<ILoginView>();
        }

        [TestMethod]
        public void HavingANullAuthenticationService_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new LoginUseCase(null, loginView.Object);
            });
        }

        [TestMethod]
        public void HavingANullLoginView_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new LoginUseCase(authenticationService.Object, null);
            });
        }

        [TestMethod]
        public void HappyFlowAuthenticationServiceAndLoginView_WhenInitializingTheUseCase_NoExceptionIsThrown()
        {
            Assert.IsNotNull(new LoginUseCase(authenticationService.Object, loginView.Object));
        }
    }
}
