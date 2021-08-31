using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachineDomain.Models;
using VendingMachineDomain;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories
{
    public class EntityFrameworkSoldsRepository : ISoldProductRepository
    {
        private readonly VendingMachineContext context;

        public EntityFrameworkSoldsRepository(VendingMachineContext context)
        {
            this.context = context;
        }

        public void Add(DateTime dateOfTranzaction, string name, float price, string paymentMethod)
        {
            var newSoldProduct = new SoldProduct
            {
                DateOfTheTranzaction = dateOfTranzaction,
                Name = name,
                Price = price,
                PaymentMethod = paymentMethod
            };

            context.Add(newSoldProduct);
            context.SaveChanges();
        }

        public IList<SoldProduct> GetAll()
        {
            return context.SoldProducts.ToList();
        }

        public IList<SoldProduct> GetAll(DateTime startDate, DateTime endDate)
        {
            return GetAll().Where(x => x.DateOfTheTranzaction >= startDate && x.DateOfTheTranzaction <= endDate).ToList();
        }
    }
}
