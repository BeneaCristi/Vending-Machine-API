using iQuest.VendingMachine.UseCases.Interfaces;
using iQuest.VendingMachine.PresentationLayer.Commands.Reports;
using iQuest.VendingMachine.Services.Authentication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace VendingMachine.Tests.Commands.StockReportCommandTests
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

            StockReportCommand logoutUseCase = new StockReportCommand(authenticationService.Object, useCaseFactory.Object);

            Assert.IsFalse(logoutUseCase.CanExecute);
        }

        [TestMethod]
        public void HavingAdminLoggedIn_CanExecuteIsTrue()
        {
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(true);

            StockReportCommand logoutUseCase = new StockReportCommand(authenticationService.Object, useCaseFactory.Object);

            Assert.IsTrue(logoutUseCase.CanExecute);
        }
    }
}
