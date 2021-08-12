using CraftStore.Web.Models;
using System.Threading.Tasks;

namespace CraftStore.Web.Services.Interfaces
{
    public interface IDbProductService : IProductService
    {
        Task AddProductAsync(Product product);

        Task UpdateProductAsync(Product product);

        Task DeleteProductAsync(string id);
    }
}