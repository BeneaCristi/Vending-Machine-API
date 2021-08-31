using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachineDomain.Models;
using iQuest.VendingMachine.UseCases.Reports.Interfaces;
using System.Xml.Linq;

namespace iQuest.VendingMachine.UseCases.Reports.Services
{
    internal class ReportsSerializerXML : IReportsSerializer
    {
        public ReportsSerializerXML()
        {
           
        }

        public string SerializeStockReport(IEnumerable<Product> products)
        {
            var xmlFormat =  new XElement("StockReport", products
                          .Select(p => new XElement("Product",
                                              new XElement("Name", p.Name),
                                              new XElement("Quantity", p.Quantity))));

            return xmlFormat.ToString();
        }

        public string SerializeSalesReport(IEnumerable<SoldProduct> soldProducts)
        {
            var xmlFormat = new XElement("SalesReport", 
                   soldProducts.Select(p => new XElement("Sales",
                                                  new XElement("Date", p.DateOfTheTranzaction),
                                                  new XElement("Name", p.Name),
                                                  new XElement("Price", p.Price),
                                                  new XElement("PaymentMethod", p.PaymentMethod))));

            return xmlFormat.ToString();    
        }

        public string SerializeVolumeReport(DateTime startDate, DateTime endDate, IEnumerable<SoldProduct> soldProducts)
        {
            var xmlFormat = new XElement("VolumeReport", 
                                new XElement("StartDate", startDate),
                                new XElement("EndDate", endDate),
                                soldProducts.GroupBy(x => x.Name).Select(p => new XElement("Sales",
                                       new XElement("Name", p.Key),
                                       new XElement("Quantity",GetQuantity(p.Key,soldProducts)))));

            return xmlFormat.ToString();
        }

        private int GetQuantity(string name, IEnumerable<SoldProduct> list)
        {
            int quantity = 0;

            foreach(var p in list)
            {
                if(p.Name == name)
                    quantity++;
            }

            return quantity;
        }
    }
}