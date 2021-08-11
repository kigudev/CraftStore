using CraftStore.Web.Models;
using CraftStore.Web.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CraftStore.Web.Services.Implementations
{
    public class JsonFileProductService: IProductService
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

        public IEnumerable<Product> GetProducts()
        {
            // leer nuestro archivo de json
            using var jsonFileReader = File.OpenText(JsonFileName);
            // regresarlo en objeto de .net
            return JsonSerializer.Deserialize<List<Product>>(jsonFileReader.ReadToEnd(), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public Product GetProduct(string id) => GetProducts().FirstOrDefault(c => c.Id == id);

        public IEnumerable<Product> GetMakerProducts(string name) => GetProducts().Where(c => c.Maker == name);

    }
}