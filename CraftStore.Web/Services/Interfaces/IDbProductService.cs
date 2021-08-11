using CraftStore.Web.Models;
using System.Threading.Tasks;

namespace CraftStore.Web.Services.Interfaces
{
    public interface IDbProductService : IProductService
    {
        Task AddProduct(Product product);

        Task UpdateProduct(Product product);

        Task DeleteProduct(int id);
    }
}