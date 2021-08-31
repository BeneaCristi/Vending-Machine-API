using iQuest.VendingMachine.Services.Authentication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using iQuest.VendingMachine.PresentationLayer.Commands;
using iQuest.VendingMachine.UseCases.Interfaces;
using Moq;

namespace VendingMachine.Tests.UseCases.LogoutUseCaseTests
{
    [TestClass]
    public class CanExecuteTests
    {
        private Mock<IAuthenticationService> authenticationService;
        private Mock<IUseCaseFactory> useCaseFactory;

        [TestInitialize]
        public void TestSetup()
        {
            authenticationService = new Mock<IAuthenticationService>();
            useCaseFactory = new Mock<IUseCaseFactory>();
        }

        [TestMethod]
        public void HavingNoAdminLoggedIn_CanExecuteIsFalse()
        {
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(false);

            LogOutCommand logoutUseCase = new LogOutCommand(useCaseFactory.Object, authenticationService.Object);

            Assert.IsFalse(logoutUseCase.CanExecute);
        }

        [TestMethod]
        public void HavingAdminLoggedIn_CanExecuteIsTrue()
        {
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(true);

            LogOutCommand logoutUseCase = new LogOutCommand(useCaseFactory.Object, authenticationService.Object);

            Assert.IsTrue(logoutUseCase.CanExecute);
        }
    }
}
