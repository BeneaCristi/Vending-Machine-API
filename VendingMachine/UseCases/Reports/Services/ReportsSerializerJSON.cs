using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using VendingMachineDomain.Models;
using iQuest.VendingMachine.UseCases.Reports.Interfaces;
using LiteDB;

namespace iQuest.VendingMachine.UseCases.Reports.Services
{
    internal class ReportsSerializerJSON : IReportsSerializer
    {
        public ReportsSerializerJSON()
        {
 
        }

        public string SerializeStockReport(IEnumerable<Product> products)
        {
            products.Select(p => new { p.Name, p.Quantity }).ToList();

            string JSONResult = JsonConvert.SerializeObject(products, Formatting.Indented);
            return JSONResult;
        }

        public string SerializeSalesReport(IEnumerable<SoldProduct> soldProducts)
        {
            var jsonFormat = soldProducts.Select(p => new
            {
                p.DateOfTheTranzaction,
                p.Name,
                p.Price,
                p.PaymentMethod
            });

            string json = JsonConvert.SerializeObject(jsonFormat, Formatting.Indented);
            return json;
        }

        public string SerializeVolumeReport(DateTime startDate, DateTime endDate, IEnumerable<SoldProduct> soldProducts)
        {
            var Products = soldProducts.GroupBy(x => x.Name).Select(p => new
            {
                p.Key,
                Quantity = GetQuantity(p.Key, soldProducts)
            });;

            var jsonFormat = new
            {
                startDate,
                endDate,
                Products
            };

            string json = JsonConvert.SerializeObject(jsonFormat, Formatting.Indented);
            return json;
        }

        private int GetQuantity(string name, IEnumerable<SoldProduct> list)
        {
            int quantity = 0;

            foreach (var p in list)
            {
                if (p.Name == name)
                    quantity++;
            }

            return quantity;
        }
    }
}