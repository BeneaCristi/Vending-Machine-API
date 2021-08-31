
namespace VendingMachineDomain.Models
{
    public class Product
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public float? Price { get; set; }
        public int? Quantity { get; set; }
        

        public Product(int? id, string name, float? price, int? quantity)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }

        public Product() { }
    }
}
