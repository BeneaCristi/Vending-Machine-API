using System;
using DataAccess.Repositories.Interfaces;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.UseCases.Reports.UseCaseList;
using iQuest.VendingMachine.UseCases.Reports.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace VendingMachine.Tests.UseCases.StockReportUseCaseTests
{
    [TestClass]
    public class ConstructorTests
    {
        private Mock<IReportsView> reportsView;
        private Mock<IReportsSerializer> reportsSerializer;
        private Mock<IProductRepository> productRepo;
        private Mock<IFileService> fileService;

        [TestInitialize]
        public void TestSetup()
        {
            reportsView = new Mock<IReportsView>();
            reportsSerializer = new Mock<IReportsSerializer>();
            productRepo = new Mock<IProductRepository>();
            fileService = new Mock<IFileService>();
        }

        [TestMethod]
        public void HavingANullReportsSerializer_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new StockReportUseCase(null, reportsView.Object, productRepo.Object, fileService.Object);
            });
        }

        [TestMethod]
        public void HavingANullReportsView_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new StockReportUseCase(reportsSerializer.Object, null, productRepo.Object, fileService.Object);
            });
        }

        [TestMethod]
        public void HavingANullProductRepo_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new StockReportUseCase(reportsSerializer.Object, reportsView.Object, null, fileService.Object);
            });
        }

        [TestMethod]
        public void HavingANullFileService_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new StockReportUseCase(reportsSerializer.Object, reportsView.Object, productRepo.Object, null);
            });
        }

        [TestMethod]
        public void HappyFlow_WhenInitializingTheUseCase_NoExceptionIsThrown()
        {
            Assert.IsNotNull(new StockReportUseCase(reportsSerializer.Object, reportsView.Object, productRepo.Object, fileService.Object));
        }
    }
}
