using System;
using DataAccess.Repositories.Interfaces;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.UseCases.Reports.UseCaseList;
using iQuest.VendingMachine.UseCases.Reports.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace VendingMachine.Tests.UseCases.VolumeReportUseCaseTests
{
    [TestClass]
    public class ConstructorTests
    {
        private Mock<IReportsView> reportsView;
        private Mock<IReportsSerializer> reportsSerializer;
        private Mock<ISoldProductRepository> soldProductRepo;
        private Mock<IFileService> fileService;

        [TestInitialize]
        public void TestSetup()
        {
            reportsView = new Mock<IReportsView>();
            reportsSerializer = new Mock<IReportsSerializer>();
            soldProductRepo = new Mock<ISoldProductRepository>();
            fileService = new Mock<IFileService>();
        }

        [TestMethod]
        public void HavingANullReportsSerializer_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new VolumeReportUseCase(null, reportsView.Object, soldProductRepo.Object, fileService.Object);
            });
        }

        [TestMethod]
        public void HavingANullReportsView_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new VolumeReportUseCase(reportsSerializer.Object, null, soldProductRepo.Object, fileService.Object);
            });
        }

        [TestMethod]
        public void HavingANullSoldProductRepo_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new VolumeReportUseCase(reportsSerializer.Object, reportsView.Object, null, fileService.Object);
            });
        }

        [TestMethod]
        public void HavingANullFileService_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new VolumeReportUseCase(reportsSerializer.Object, reportsView.Object, soldProductRepo.Object, null);
            });
        }

        [TestMethod]
        public void HappyFlow_WhenInitializingTheUseCase_NoExceptionIsThrown()
        {
            Assert.IsNotNull(new VolumeReportUseCase(reportsSerializer.Object, reportsView.Object, soldProductRepo.Object, fileService.Object));
        }
    }
}
