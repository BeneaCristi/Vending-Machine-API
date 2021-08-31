using System;
using iQuest.VendingMachine.PresentationLayer.Commands;
using iQuest.VendingMachine.UseCases.Interfaces;
using iQuest.VendingMachine.Services.Authentication;
using DataAccess.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace VendingMachine.Tests.Commands.BuyCommandTests
{
    [TestClass]
    public class ConstructorTests
    {
        private Mock<IUseCaseFactory> useCaseFactory;
        private Mock<IProductRepository> productRepo;
        private Mock<IAuthenticationService> authemticationService;

        [TestInitialize]
        public void TestSetup()
        {
            useCaseFactory = new Mock<IUseCaseFactory>();
            productRepo = new Mock<IProductRepository>();
            authemticationService = new Mock<IAuthenticationService>();
        }

        [TestMethod]
        public void HavingANullUseCaseFactory_WhenInitializingTheCommand_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new BuyCommand(null, productRepo.Object, authemticationService.Object);
            });
        }

        [TestMethod]
        public void HavingANullProductRepository_WhenInitializingTheCommand_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new BuyCommand(useCaseFactory.Object, null, authemticationService.Object);
            });
        }

        [TestMethod]
        public void HavingANullAuthenticationService_WhenInitializingTheCommand_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new BuyCommand(useCaseFactory.Object, productRepo.Object, null);
            });
        }

        [TestMethod]
        public void HappyFlow_WhenInitializingTheCommand_NoExceptionIsThrown()
        {
            Assert.IsNotNull(new BuyCommand(useCaseFactory.Object, productRepo.Object, authemticationService.Object));
        }
    }
}
