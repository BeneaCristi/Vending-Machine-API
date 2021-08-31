using System.Collections.Generic;
using VendingMachineDomain.Models;
using System;

namespace iQuest.VendingMachine.UseCases.Reports.Interfaces
{
    internal interface IReportsSerializer
    {
        public string SerializeStockReport(IEnumerable<Product> products);
        public string SerializeSalesReport(IEnumerable<SoldProduct> soldProducts);
        public string SerializeVolumeReport(DateTime startDate, DateTime endDate, IEnumerable<SoldProduct> soldProducts);
    }
}
