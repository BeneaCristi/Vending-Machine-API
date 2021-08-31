using System.Collections.Generic;
using DataAccess.Models;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.UseCases.UseCaseList;
using DataAccess.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace VendingMachine.Tests.UseCases.LookUseCaseTests
{
    [TestClass]
    public class ExecuteTests
    {
        private Mock<IProductRepository> productRepo;
        private Mock<IShelfView> shelfView;
        private LookUseCase lookUseCase;

        [TestInitialize]
        public void TestInitialize()
        {
            productRepo = new Mock<IProductRepository>();
            shelfView = new Mock<IShelfView>();
            lookUseCase = new LookUseCase(productRepo.Object, shelfView.Object);
        }

        [TestMethod]
        public void HavingAUseCaseInstance_WhenExecutedSuccesfully_ThenShowTheListOfProducts()
        {
            List<Product> p = new List<Product>()
            {

            };

            productRepo
                .Setup(x => x.GetAll())
                .Returns(p);

            lookUseCase.Execute();

            shelfView.Verify(x => x.DisplayProducts(It.IsAny<List<Product>>()));
        }
    }
}
