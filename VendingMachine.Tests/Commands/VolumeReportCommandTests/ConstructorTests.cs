using System;
using iQuest.VendingMachine.PresentationLayer.Commands.Reports;
using iQuest.VendingMachine.UseCases.Interfaces;
using iQuest.VendingMachine.Services.Authentication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace VendingMachine.Tests.Commands.VolumeReportCommandTests
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
                new VolumeReportCommand(authenticationService.Object, null);
            });
        }

        [TestMethod]
        public void HavingANullAuthenticationService_WhenInitializingTheCommand_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new VolumeReportCommand(null, useCaseFactory.Object);
            });
        }

        [TestMethod]
        public void HappyFlow_WhenInitializingTheCommand_NoExceptionIsThrown()
        {
            Assert.IsNotNull(new VolumeReportCommand(authenticationService.Object, useCaseFactory.Object));
        }
    }
}
