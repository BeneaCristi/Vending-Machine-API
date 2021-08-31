using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using System.Collections.Generic;
using DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess.Repositories.Interfaces;
using iQuest.VendingMachine.UseCases.Reports.UseCaseList;
using iQuest.VendingMachine.UseCases.Reports.Interfaces;
using Moq;

namespace VendingMachine.Tests.UseCases.StockReportUseCaseTests
{
    [TestClass]
    public class ExecuteTests
    {
        private Mock<IReportsView> stockView;
        private Mock<IReportsSerializer> reportsSerializer;
        private Mock<IProductRepository> productRepo;
        private Mock<IFileService> fileService;
        private StockReportUseCase stockUseCase;

        [TestInitialize]
        public void TestSetup()
        {
            stockView = new Mock<IReportsView>();
            reportsSerializer = new Mock<IReportsSerializer>();
            productRepo = new Mock<IProductRepository>();
            fileService = new Mock<IFileService>();

            stockUseCase = new StockReportUseCase(reportsSerializer.Object, stockView.Object, productRepo.Object, fileService.Object);
        }

        [TestMethod]
        public void HavingAStockReportUseCaseInstance_WhenExecuted_ThenShowFormat()
        {
            //arrange

            //act
            stockUseCase.Execute();

            //assert
            stockView.Verify(x => x.TellFileFormat(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void HavingAStockReportUseCase_WhenExecuted_ThenCallSerializer()
        {
            //arrange
            

            //act
            stockUseCase.Execute();

            //assert
            reportsSerializer.Verify(x => x.SerializeStockReport(It.IsAny<IEnumerable<Product>>()), Times.Once);
        }

        [TestMethod]
        public void HavingAStockReportUseCase_WhenExecuted_ThenCallCreatedMessageMethod()
        {
            //arrange

            //act
           stockUseCase.Execute();

            //assert
            stockView.Verify(x => x.CreatedMessage(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}