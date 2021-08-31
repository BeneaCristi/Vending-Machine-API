using Microsoft.EntityFrameworkCore;
using VendingMachineDomain.Models;

namespace VendingMachineDomain
{
    public class VendingMachineContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlite(@"Data Source=C:\Users\OMEN\Desktop\Vending Machine API\DataAccess\testdb1.db");


        public DbSet<Product> Products { get; set; }
        public DbSet<SoldProduct> SoldProducts { get; set; }
    }
}
