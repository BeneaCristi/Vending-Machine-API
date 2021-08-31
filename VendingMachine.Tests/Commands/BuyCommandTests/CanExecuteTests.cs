using DataAccess.Repositories.Interfaces;
using DataAccess.Models;
using iQuest.VendingMachine.UseCases.Interfaces;
using iQuest.VendingMachine.PresentationLayer.Commands;
using iQuest.VendingMachine.Services.Authentication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace VendingMachine.Tests.UseCases.BuyUseCaseTests
{
    [TestClass]
    public class CanExecuteTests
    {
        private Mock<IProductRepository> productRepo;
        private Mock<IUseCaseFactory> useCaseFactory;
        private Mock<IAuthenticationService> authemticationService;

        [TestInitialize]
        public void TestSetup()
        {
            productRepo = new Mock<IProductRepository>();
            useCaseFactory = new Mock<IUseCaseFactory>();
            authemticationService = new Mock<IAuthenticationService>();
        }

        [TestMethod]
        public void HavingListOfProducts_CanExecuteIsTrue()
        {
            List<Product> productsList = new List<Product>()
            {
                new Product(0,"name",1f,2),
            };

            productRepo
                 .Setup(x => x.GetAll())
                 .Returns(productsList);

            var buyUseCase = new BuyCommand(useCaseFactory.Object, productRepo.Object, authemticationService.Object);

            Assert.IsTrue(buyUseCase.CanExecute);
        }

        [TestMethod]
        public void HavingNoListOfProducts_CanExecuteIsFalse()
        {
            productRepo
                 .Setup(x => x.GetAll())
                 .Returns(new List<Product>());

            var buyUseCase = new BuyCommand(useCaseFactory.Object, productRepo.Object, authemticationService.Object);

            Assert.IsFalse(buyUseCase.CanExecute);
        }
    }
}
