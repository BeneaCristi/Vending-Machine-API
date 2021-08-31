using iQuest.VendingMachine.Services.Authentication;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.UseCases.UseCaseList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace VendingMachine.Tests.UseCases.LoginUseCaseTests
{
    [TestClass]
    public class ExecuteTests
    {
        private Mock<IAuthenticationService> authenticationService;
        private Mock<ILoginView> loginView;
        private LoginUseCase loginUseCase;

        [TestInitialize]
        public void TestInitialize()
        {
            authenticationService = new Mock<IAuthenticationService>();
            loginView = new Mock<ILoginView>();
            loginUseCase = new LoginUseCase(authenticationService.Object, loginView.Object);
        }

        [TestMethod]
        public void HavingALoginUseCaseInstance_WhenExecuted_ThenUserIsAskedToIntroducePassword()
        {
            //arrange
            //act
            loginUseCase.Execute();

            //assert
            loginView.Verify(x => x.AskForPassword(), Times.Once);
        }

        [TestMethod]
        public void HavingALoginUseCaseInstance_WhenExecuted_ThenUserIsAuthenticated()
        {
            //arrange
            loginView
                 .Setup(x => x.AskForPassword())
                 .Returns("pass123");

            //act
            loginUseCase.Execute();

            //assert
            authenticationService.Verify(x => x.Login("pass123"), Times.Once);
        }
    }
}
