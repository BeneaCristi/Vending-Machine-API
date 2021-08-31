using System;
using DataAccess.Models;
using System.Collections.Generic;
using DataAccess.Repositories.Interfaces;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using iQuest.VendingMachine.UseCases.Reports.UseCaseList;
using iQuest.VendingMachine.UseCases.Reports.Interfaces;
using Moq;

namespace VendingMachine.Tests.UseCases.VolumeReportUseCaseTests
{
    [TestClass]
    public class ExecuteTests
    {
        private Mock<IReportsView> volumeView;
        private Mock<IReportsSerializer> reportsSerializer;
        private Mock<ISoldProductRepository> soldProductRepo;
        private Mock<IFileService> fileService;
        private VolumeReportUseCase volumeUseCase;

        [TestInitialize]
        public void TestSetup()
        {
            volumeView = new Mock<IReportsView>();
            reportsSerializer = new Mock<IReportsSerializer>();
            soldProductRepo = new Mock<ISoldProductRepository>();
            fileService = new Mock<IFileService>();

            volumeUseCase = new VolumeReportUseCase(reportsSerializer.Object, volumeView.Object, soldProductRepo.Object, fileService.Object);
        }

        [TestMethod]
        public void HavingAVolumeReportUseCaseInstance_WhenExecuted_ThenShowFormat()
        {
            //arrange

            //act
            volumeUseCase.Execute();

            //assert
            volumeView.Verify(x => x.TellFileFormat(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void HavingAVolumeReportUseCaseInstance_WhenExecuted_ThenCallSerializer()
        {
            //arrange

            //act
            volumeUseCase.Execute();

            //assert
            reportsSerializer.Verify(x => x.SerializeVolumeReport(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<IEnumerable<SoldProduct>>()), Times.Once);
        }

        [TestMethod]
        public void HavingASalesReportUseCase_WhenExecuted_ThenCallCreatedMessageMethod()
        {
            //arrange

            //act
            volumeUseCase.Execute();

            //assert
            volumeView.Verify(x => x.CreatedMessage(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
