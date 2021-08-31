using System;
using System.Configuration;
using DataAccess.Repositories.Interfaces;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.UseCases.Interfaces;
using iQuest.VendingMachine.UseCases.Reports.Interfaces;

namespace iQuest.VendingMachine.UseCases.Reports.UseCaseList
{
    internal class SalesReportUseCase : IUseCase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly string format = ConfigurationManager.AppSettings["Format"];

        private readonly IReportsSerializer reportsSerializer;
        private readonly IReportsView salesView;
        private readonly ISoldProductRepository soldProductRepo;
        private readonly IFileService fileService;

        public SalesReportUseCase(IReportsSerializer reportsSerializer, IReportsView salesView, ISoldProductRepository soldProductRepo, IFileService fileService)
        {
            this.reportsSerializer = reportsSerializer ?? throw new ArgumentNullException(nameof(reportsSerializer));
            this.salesView = salesView ?? throw new ArgumentNullException(nameof(salesView));
            this.soldProductRepo = soldProductRepo ?? throw new ArgumentNullException(nameof(soldProductRepo));
            this.fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }

        public void Execute()
        {
            salesView.TellFileFormat(format);
            DateTime startDate = salesView.AskForADate("START");
            DateTime endDate = salesView.AskForADate("END");
            var listOfSoldProductsInTimeRange = soldProductRepo.GetAll(startDate,endDate);
            var report = reportsSerializer.SerializeSalesReport(listOfSoldProductsInTimeRange);
            fileService.Save(report, format, "SalesReports", GetNameAndDateFormat());
            salesView.CreatedMessage(format, "SalesReport");

            log.Info($"SALES REPORT was CREATED for the interval : {startDate} - {endDate}\n");
        }

        private string GetNameAndDateFormat()
        {
            DateTime prezentDate = DateTime.Now;
            string name = "Sales Report - ";
            string dateFormat = name + prezentDate.ToString("yyyy MM dd HHmmss");

            return dateFormat;
        }
    }
}