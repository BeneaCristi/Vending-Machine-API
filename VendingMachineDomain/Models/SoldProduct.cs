using System;

namespace VendingMachineDomain.Models
{
    public class SoldProduct
    {
        public int Id { get; set; }
        public DateTime DateOfTheTranzaction { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string PaymentMethod { get; set; }
        public int Quantity { get; set; }

        public SoldProduct() { }

        public SoldProduct(string name, float price, string paymentMethod, DateTime dateOfTheTranzaction)
        {
            this.Name = name;
            this.Price = price;
            this.PaymentMethod = paymentMethod;
            this.DateOfTheTranzaction = dateOfTheTranzaction;
        }
    }
}
