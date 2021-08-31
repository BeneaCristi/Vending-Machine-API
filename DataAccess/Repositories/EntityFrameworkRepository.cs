using System.Collections.Generic;
using System.Linq;
using VendingMachineDomain.Exceptions;
using VendingMachineDomain.Models;
using VendingMachineDomain;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories
{
    public class EntityFrameworkRepository : IProductRepository
    {
        private readonly VendingMachineContext context;

        private List<int?> ids = new List<int?>();

        public EntityFrameworkRepository(VendingMachineContext context) 
        {
            this.context = context;
        }

        public void AddNewProductType(string name, int stock, double price)
        {
            ids = GetIds();

            var p = new Product
            {
                Id = SetId(ids),
                Name = name,
                Quantity = stock,
                Price = (float)price

            };

            context.Add(p);
            ids.Add(p.Id);
            context.SaveChanges();
        }

        public void DeleteProductType(int id)
        {
            ids = GetIds();

            context.Remove(GetById(id));
            ids.Remove(id);

            context.SaveChanges();
        }

        public void ChangeProductName(int id, string name)
        {
            var p = GetById(id);

            p.Name = name;

            context.Update(p);
            context.SaveChanges();
        }

        public void ChangeProductPrice(int id, double price)
        {
            var p = GetById(id);

            p.Price = (float)price;

            context.Update(p);
            context.SaveChanges();
        }

        public void ChangeProductStock(int id, int stock)
        {
            var p = GetById(id);

            p.Quantity = stock;

            context.Update(p);
            context.SaveChanges();
        }

        public void DecrementStock(int id)
        {
            var p = GetById(id);

            p.Quantity--;

            context.Update(p);
            context.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product GetById(int id)
        {
            ids = GetIds();

            if (ids.Contains(id) == false)
            {
                throw new InvalidProductIdException();
            }

            return context.Products.Where(x => x.Id == id).FirstOrDefault();
        }

        public void IsIdValid(int id)
        {
            var p = GetById(id);

            if(p == null)
                throw new InvalidProductIdException();
        }

        private List<int?> GetIds()
        {
            var products = GetAll().ToList();

            List<int?> ids = new List<int?>();

            foreach(var product in products)
            {
                ids.Add(product.Id);
            }

            return ids;
        }

        private int SetId(List<int?> ids)
        {
            int min = 1;

            foreach(var id in ids)
            {
                if (id == min)
                {
                    min++;
                }
            }

            return min;
        }
    }
}
