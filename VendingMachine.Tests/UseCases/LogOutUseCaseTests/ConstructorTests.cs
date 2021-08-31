using iQuest.VendingMachine.UseCases.UseCaseList;
using iQuest.VendingMachine.Services.Authentication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;

namespace VendingMachine.Tests.UseCases.LogoutUseCaseTests
{
    [TestClass]
    public class ConstructorTests
    {
        private Mock<IAuthenticationService> authenticationService;

        [TestInitialize]
        public void TestSetup()
        {
            authenticationService = new Mock<IAuthenticationService>();
        }

        [TestMethod]
        public void HavingANullAuthenticationService_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new LogoutUseCase(null);
            });
        }

        [TestMethod]
        public void HappyFlowAuthenticationService_WhenInitializingTheUseCase_NoExceptionIsThrown()
        {
            Assert.IsNotNull(new LogoutUseCase(authenticationService.Object));
        }
    }
}
