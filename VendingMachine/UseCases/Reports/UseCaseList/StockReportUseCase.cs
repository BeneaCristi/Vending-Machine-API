using System;
using System.Configuration;
using iQuest.VendingMachine.PresentationLayer.Views.Interfaces;
using iQuest.VendingMachine.UseCases.Interfaces;
using iQuest.VendingMachine.UseCases.Reports.Interfaces;
using DataAccess.Repositories.Interfaces;

namespace iQuest.VendingMachine.UseCases.Reports.UseCaseList
{
    internal class StockReportUseCase : IUseCase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly string format = ConfigurationManager.AppSettings["Format"];

        private readonly IReportsSerializer reportsSerializer;
        private readonly IReportsView stockView;
        private readonly IProductRepository productRepo;
        private readonly IFileService fileService;

        public StockReportUseCase(IReportsSerializer reportsSerializer, IReportsView stockView, IProductRepository productRepo, IFileService fileService)
        {
            this.reportsSerializer = reportsSerializer ?? throw new ArgumentNullException(nameof(reportsSerializer));
            this.stockView = stockView ?? throw new ArgumentNullException(nameof(stockView));
            this.productRepo = productRepo ?? throw new ArgumentNullException(nameof(productRepo));
            this.fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }

        public void Execute()
        {
            stockView.TellFileFormat(format);
            var listOfProducts = productRepo.GetAll();
            var report = reportsSerializer.SerializeStockReport(listOfProducts);
            fileService.Save(report, format, "StockReports", GetNameAndDateFormat());
            stockView.CreatedMessage(format, "StockReport");

            log.Info($"STOCK REPORT was CREATED\n");
        }

        private string GetNameAndDateFormat()
        {
            DateTime prezentDate = DateTime.Now;
            string name = "Stock Report - ";
            string dateFormat = name + prezentDate.ToString("yyyy MM dd HHmmss");

            return dateFormat;
        }
    }
}