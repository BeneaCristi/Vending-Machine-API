using System.Collections.Generic;
using DataAccess.Repositories.Interfaces;
using VendingMachineDomain.Exceptions;
using VendingMachineDomain.Models;
using System.Linq;
using LiteDB;

namespace DataAccess.Repositories
{
    public class LiteDBRepository : IProductRepository
    {
        private readonly ILiteCollection<Product> collection;

        public LiteDBRepository(string connectionString)
        {
            var db = new LiteDatabase(connectionString);
            collection = db.GetCollection<Product>("Products");

            List<Product> dbProducts = new List<Product>()
            {
                new Product(1,"Cola",12.5f,3),
                new Product(2,"Snickers",13f,4),
                new Product(3,"Redbull",13.5f,5),
                new Product(4,"7days",14f,6)
            };

            collection.DeleteAll();
            collection.InsertBulk(dbProducts);
        }

        public void DecrementStock(int id)
        {
            var product = collection.FindById(id);

            if (product.Quantity > 0)
            {
                product.Quantity--;
                collection.Update(product);
            }
            else
                throw new InsufficientStockException(product.Name);  
        }

        public IEnumerable<Product> GetAll()
        {
            return collection.FindAll().ToList();
        }

        public Product GetById(int id)
        {
            if (id <= collection.Count() && id > 0)
                return collection.FindById(id);
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

            collection.Insert(p);
        }

        public void DeleteProductType(int id)
        {
            collection.Delete(id);
        }

        public void ChangeProductName(int id, string name)
        {
            var p = GetById(id);

            p.Name = name;

            collection.Update(p);
        }

        public void ChangeProductPrice(int id, double price)
        {
            var p = GetById(id);

            p.Price = (float)price;

            collection.Update(p);
        }

        public void ChangeProductStock(int id, int stock)
        {
            var p = GetById(id);

            p.Quantity = stock;

            collection.Update(p);
        }
    }
}