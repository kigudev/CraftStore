using CraftStore.Web.Models;
using System.Collections.Generic;

namespace CraftStore.Web.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();

        Product GetProduct(string id);

        IEnumerable<Product> GetMakerProducts(string name);
    }
}