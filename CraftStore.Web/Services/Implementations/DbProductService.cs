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

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
        public async Task AddProductAsync(Product product)
        {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(string id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);

            if (product == null)
                return;

            _context.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product newProduct)
        {
            var product = await _context.Products.FirstOrDefaultAsync(c => c.Id == newProduct.Id);

            if (product == null)
                return;

            product.Maker = newProduct.Maker;
            product.Url = newProduct.Url;
            product.Image = newProduct.Image;
            product.Title = newProduct.Title;
            product.Description = newProduct.Description;

            await _context.SaveChangesAsync();
        }


    }
}