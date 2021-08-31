using DataAccess.Models;
using System.Collections.Generic;
using DataAccess.Repositories.Interfaces;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using iQuest.VendingMachine.UseCases.Reports.UseCaseList;
using iQuest.VendingMachine.UseCases.Reports.Interfaces;
using Moq;

namespace VendingMachine.Tests.UseCases.SalesReportUseCaseTest
{
    [TestClass]
    public class ExecuteTests
    {
        private Mock<IReportsView> salesView;
        private Mock<IReportsSerializer> reportsSerializer;
        private Mock<ISoldProductRepository> soldProductRepo;
        private Mock<IFileService> fileService;
        private SalesReportUseCase salesUseCase;

        [TestInitialize]
        public void TestSetup()
        {
            salesView = new Mock<IReportsView>();
            reportsSerializer = new Mock<IReportsSerializer>();
            soldProductRepo = new Mock<ISoldProductRepository>();
            fileService = new Mock<IFileService>();

            salesUseCase = new SalesReportUseCase(reportsSerializer.Object, salesView.Object, soldProductRepo.Object, fileService.Object);
        }

        [TestMethod]
        public void HavingASalesReportUseCaseInstance_WhenExecuted_ThenShowFormat()
        {
            //arrange

            //act
            salesUseCase.Execute();

            //assert
            salesView.Verify(x => x.TellFileFormat(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void HavingASalesReportUseCase_WhenExecutedN_ThenCallSerializer()
        {
            //arrange

            //act
            salesUseCase.Execute();

            //assert
            reportsSerializer.Verify(x => x.SerializeSalesReport(It.IsAny<IEnumerable<SoldProduct>>()), Times.Once);
        }

        [TestMethod]
        public void HavingASalesReportUseCase_WhenExecuted_ThenCallCreatedMessageMethod()
        {
            //arrange

            //act
            salesUseCase.Execute();

            //assert
            salesView.Verify(x => x.CreatedMessage(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
