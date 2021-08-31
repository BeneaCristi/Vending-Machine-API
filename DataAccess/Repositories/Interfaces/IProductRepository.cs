using System.Collections.Generic;
using System.Runtime.CompilerServices;
using VendingMachineDomain.Models;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace DataAccess.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();

        void DecrementStock(int id);

        Product GetById(int id);

        void IsIdValid(int id);

        void AddNewProductType(string name, int stock, double price);

        void DeleteProductType(int id);

        void ChangeProductName (int id, string name);

        void ChangeProductStock (int id, int stock);

        void ChangeProductPrice (int id, double price);
    }
}