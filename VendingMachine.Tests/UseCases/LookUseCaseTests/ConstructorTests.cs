using System;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.UseCases.UseCaseList;
using DataAccess.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace VendingMachine.Tests.UseCases.LookUseCaseTests
{
    [TestClass]
    public class ConstructorTests
    {
        private Mock<IProductRepository> productRepo;
        private Mock<IShelfView> shelfView;

        [TestInitialize]
        public void TestSetup()
        {
            productRepo = new Mock<IProductRepository>();
            shelfView = new Mock<IShelfView>();
        }

        [TestMethod]
        public void HavingANullProductRepository_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new LookUseCase(null, shelfView.Object);
            });
        }

        [TestMethod]
        public void HavingANullShelfView_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new LookUseCase(productRepo.Object, null);
            });
        }

        [TestMethod]
        public void HappyFlowpRroductRepositoryAndShelfView_WhenInitializingTheUseCase_NoExceptionIsThrown()
        {
            Assert.IsNotNull(new LookUseCase(productRepo.Object, shelfView.Object));
        }
    }
}
