using CraftStore.Web.Data;
using CraftStore.Web.Models;
using CraftStore.Web.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CraftStore.Web.Services.Implementations
{
    public class DbProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public DbProductService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<Product> GetMakerProducts(string name) => _context.Products.Where(c => c.Maker == name);

        public Product GetProduct(string id) => _context.Products.FirstOrDefault(c => c.Id == id);

        public IEnumerable<Product> GetProducts() => _context.Products;
    }
}