using System;
using DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using VendingMachineDomain.Models;
using System.Linq;
using LiteDB;

namespace DataAccess.Repositories
{
    public class LiteDBRepositorySold : ISoldProductRepository
    {
        private readonly ILiteCollection<SoldProduct> collection;
        private readonly LiteDatabase db;

        public LiteDBRepositorySold(string connectionString)
        {
            db = new LiteDatabase(connectionString);
            collection = db.GetCollection<SoldProduct>("SoldProduct");
        }

        public IList<SoldProduct> GetAll()
        {
            return collection.FindAll().ToList();
        }

        public IList<SoldProduct> GetAll(DateTime startDate, DateTime endDate)
        {
            return GetAll().Where(x => x.DateOfTheTranzaction >= startDate && x.DateOfTheTranzaction <= endDate).ToList();
        }

        public void Add(DateTime dateOfTranzaction, string name, float price, string paymentMethod)
        {
            var coll = db.GetCollection<SoldProduct>();

            var newSoldProduct = new SoldProduct
            {
                DateOfTheTranzaction = dateOfTranzaction,
                Name = name,
                Price = price,
                PaymentMethod = paymentMethod
            };

           coll.Insert(newSoldProduct);
        }
    }
}
