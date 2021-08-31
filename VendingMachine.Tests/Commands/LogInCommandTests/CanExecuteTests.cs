using iQuest.VendingMachine.Services.Authentication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using iQuest.VendingMachine.UseCases.Interfaces;
using iQuest.VendingMachine.PresentationLayer.Commands;
using Moq;

namespace VendingMachine.Tests
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
        public void HavingNoAdminLoggedIn_CanExecuteIsTrue()
        {
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(false);

            LogInCommand loginUseCase = new LogInCommand(useCaseFactory.Object, authenticationService.Object);

            Assert.IsTrue(loginUseCase.CanExecute);
        }

        [TestMethod]
        public void HavingAdminLoggedIn_CanExecuteIsFalse()
        {
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(true);

            LogInCommand loginUseCase = new LogInCommand(useCaseFactory.Object, authenticationService.Object);

            Assert.IsFalse(loginUseCase.CanExecute);
        }
    }
}

