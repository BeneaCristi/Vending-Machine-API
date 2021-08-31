using iQuest.VendingMachine.Services.Authentication;
using iQuest.VendingMachine.UseCases.UseCaseList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace VendingMachine.Tests.UseCases.LogoutUseCaseTests
{
    [TestClass]
    public class ExecuteTests
    {
        [TestMethod]
        public void HavingALogoutUseCaseInstance_WhenExecuted_ThenUserIsAuthenticated()
        {
            Mock<IAuthenticationService> authenticationService = new Mock<IAuthenticationService>();
            LogoutUseCase logoutUseCase = new LogoutUseCase(authenticationService.Object);

            logoutUseCase.Execute();

            authenticationService.Verify(x => x.Logout(), Times.Once);
        }
    }
}
