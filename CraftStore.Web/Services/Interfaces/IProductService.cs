using CraftStore.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CraftStore.Web.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        Task<Product> GetProductAsync(string id);

        Task<IEnumerable<Product>> GetMakerProductsAsync(string name);
    }
}