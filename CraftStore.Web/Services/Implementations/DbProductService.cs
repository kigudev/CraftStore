using CraftStore.Web.Data;
using CraftStore.Web.Models;
using CraftStore.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftStore.Web.Services.Implementations
{
    public class DbProductService : IDbProductService
    {
        private readonly ApplicationDbContext _context;

        public DbProductService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<Product>> GetMakerProductsAsync(string name) => 
              await _context.Products.Where(c => c.Maker == name).ToListAsync();

        public async Task<Product> GetProductAsync(string id) {
            return await _context.Products.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync() {
            return await _context.Products.ToListAsync();
        }
        public Task AddProduct(Product product)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteProduct(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateProduct(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}