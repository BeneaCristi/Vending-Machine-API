using System.Collections.Generic;
using System.Runtime.CompilerServices;
using VendingMachineDomain.Models;
using System;

namespace DataAccess.Repositories.Interfaces
{
    public interface ISoldProductRepository
    {
        IList<SoldProduct> GetAll();
        IList<SoldProduct> GetAll(DateTime startDate, DateTime endDate);
        void Add(DateTime dateOfTranzaction, string name, float price, string paymentMethod);

    }
}
