using System;
using System.Configuration;
using DataAccess.Repositories.Interfaces;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.UseCases.Interfaces;
using iQuest.VendingMachine.UseCases.Reports.Interfaces;

namespace iQuest.VendingMachine.UseCases.Reports.UseCaseList
{
    internal class VolumeReportUseCase : IUseCase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly string format = ConfigurationManager.AppSettings["Format"];

        private readonly IReportsSerializer reportsSerializer;
        private readonly IReportsView volumeView;
        private readonly ISoldProductRepository soldProductRepo;
        private readonly IFileService fileService;

        public VolumeReportUseCase(IReportsSerializer reportsSerializer, IReportsView volumeView, ISoldProductRepository soldProductRepo, IFileService fileService)
        {
            this.reportsSerializer = reportsSerializer ?? throw new ArgumentNullException(nameof(reportsSerializer));
            this.volumeView = volumeView ?? throw new ArgumentNullException(nameof(volumeView));
            this.soldProductRepo = soldProductRepo ?? throw new ArgumentNullException(nameof(soldProductRepo));
            this.fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }

        public void Execute()
        {
            volumeView.TellFileFormat(format);
            DateTime startDate = volumeView.AskForADate("START");
            DateTime endDate = volumeView.AskForADate("END");
            var listOfSoldProductsInTimeRange = soldProductRepo.GetAll(startDate, endDate);
            var report = reportsSerializer.SerializeVolumeReport(startDate,endDate,listOfSoldProductsInTimeRange);
            fileService.Save(report, format, "VolumeReports", GetNameAndDateFormat());
            volumeView.CreatedMessage(format, "VolumeReport");

            log.Info($"VOLUME REPORT was CREATED for the interval {startDate} - {endDate}\n");
        }

        private string GetNameAndDateFormat()
        {
            DateTime prezentDate = DateTime.Now;
            string name = "Volume Report - ";
            string dateFormat = name + prezentDate.ToString("yyyy MM dd HHmmss");

            return dateFormat;
        }
    }
}