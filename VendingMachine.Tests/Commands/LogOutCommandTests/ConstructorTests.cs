using System;
using iQuest.VendingMachine.PresentationLayer.Commands;
using iQuest.VendingMachine.UseCases.Interfaces;
using iQuest.VendingMachine.Services.Authentication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace VendingMachine.Tests.Commands.LogOutCommandTests
{
    [TestClass]
    public class ConstructorTests
    {
        private Mock<IUseCaseFactory> useCaseFactory;
        private Mock<IAuthenticationService> authenticationService;

        [TestInitialize]
        public void TestSetup()
        {
            useCaseFactory = new Mock<IUseCaseFactory>();
            authenticationService = new Mock<IAuthenticationService>();
        }

        [TestMethod]
        public void HavingANullUseCaseFactory_WhenInitializingTheCommand_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new LogOutCommand(null, authenticationService.Object);
            });
        }

        [TestMethod]
        public void HavingANullAuthenticationService_WhenInitializingTheCommand_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new LogOutCommand(useCaseFactory.Object, null);
            });
        }

        [TestMethod]
        public void HappyFlow_WhenInitializingTheCommand_NoExceptionIsThrown()
        {
            Assert.IsNotNull(new LogOutCommand(useCaseFactory.Object, authenticationService.Object));
        }
    }
}
