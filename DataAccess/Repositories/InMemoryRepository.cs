using System.Collections.Generic;
using System.Linq;
using DataAccess.Repositories.Interfaces;
using VendingMachineDomain.Exceptions;
using VendingMachineDomain.Models;

namespace DataAccess.Repositories
{
    public class InMemoryRepository : IProductRepository
    {
        private readonly List<Product> products = new List<Product>()
        {
            new Product(0,"Cola",12.5f,3),
            new Product(1,"Snickers",13f,4),
            new Product(2,"Redbull",13.5f,5),
            new Product(3,"7days",14f,6)
        };

        public IEnumerable<Product> GetAll()
        {
            if (products.Any())
                return products;
            else
                throw new NoListException();
        }

        public void DecrementStock(int id)
        {
            if (products[id].Quantity > 0)
                products[id].Quantity--;
            else
                throw new InsufficientStockException(products[id].Name);
        }

        public Product GetById(int id)
        {
            if (id >= 0 && id < products.Count)
                return products.Where(x => x.Id == id).FirstOrDefault();
            else
                throw new InvalidProductIdException();
        }

        public void IsIdValid(int id)
        {
            var p = GetById(id);

            if (p == null)
                throw new InvalidProductIdException();
        }

        public void AddNewProductType(string name, int stock, double price)
        {
            var p = new Product
            {
                Name = name,
                Quantity = stock,
                Price = (float)price
            };

            products.Add(p);
        }

        public void DeleteProductType(int id)
        {
            products.Remove(products[id]);
        }

        public void ChangeProductName(int id, string name)
        {
            products[id].Name = name;
        }

        public void ChangeProductStock(int id, int stock)
        {
            products[id].Quantity = stock;
        }

        public void ChangeProductPrice(int id, double price)
        {
            products[id].Price = (float)price;
        }
    }
}

