using CraftStore.Web.Models;
using CraftStore.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CraftStore.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly JsonFileProductService _productService;

        public IndexModel(ILogger<IndexModel> logger, JsonFileProductService jsonFileProductService)
        {
            _logger = logger;
            _productService = jsonFileProductService;
        }

        public IEnumerable<Product> Products { get; private set; }

        public void OnGet()
        {
            Products = _productService.GetProducts();
        }
    }
}