using CraftStore.Web.Models;
using CraftStore.Web.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CraftStore.Web.Services.Implementations
{
    public class JsonFileProductService : IProductService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        private string JsonFileName
        {
            get { return Path.Combine(_webHostEnvironment.WebRootPath, "data", "products.json"); }
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            // leer nuestro archivo de json
            using var jsonFileReader = File.OpenText(JsonFileName);
            // regresarlo en objeto de .net
            return await JsonSerializer.DeserializeAsync<List<Product>>(jsonFileReader.BaseStream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<Product> GetProductAsync(string id)
        {
            var products = await GetProductsAsync();
                
            return products.FirstOrDefault(c => c.Id == id);
        }

        public async Task<IEnumerable<Product>> GetMakerProductsAsync(string name) => 
            (await GetProductsAsync()).Where(c => c.Maker == name);
    }
}