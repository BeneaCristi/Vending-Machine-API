using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendingMachineDomain;
using VendingMachineDomain.Models;

namespace VendingMachineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoldProductsController : ControllerBase
    {
        private readonly VendingMachineContext _context;

        public SoldProductsController(VendingMachineContext context)
        {
            _context = context;
        }

        // GET: api/SoldProducts
        [HttpGet]
        public IEnumerable<SoldProduct> GetSoldProducts()
        {
            return _context.SoldProducts.ToList();
        }

        // GET: /api/sales?startdate={start-date}&endtdate={end-date}
        [HttpGet("{id}")]
        public List<SoldProduct> GetSoldProduct(DateTime startDate, DateTime endDate)
        {
            var soldProduct = _context.SoldProducts.Where(x => x.DateOfTheTranzaction >= startDate && x.DateOfTheTranzaction <= endDate).ToList();

            if (soldProduct == null)
            {
                NotFound();
            }

            return soldProduct;
        }

        // DELETE: api/SoldProducts/5
        [HttpDelete("{id}")]
        public ActionResult<SoldProduct> DeleteSoldProduct(int id)
        {
            var soldProduct = _context.SoldProducts.Find(id);
            if (soldProduct == null)
            {
                return NotFound();
            }

            _context.SoldProducts.Remove(soldProduct);
           _context.SaveChanges();

            return soldProduct;
        }
    }
}
