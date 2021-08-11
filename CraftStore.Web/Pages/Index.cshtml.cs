using CraftStore.Web.Models;
using CraftStore.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CraftStore.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IProductService _productService;

        public IndexModel(ILogger<IndexModel> logger, IProductService jsonFileProductService)
        {
            _logger = logger;
            _productService = jsonFileProductService;
        }

        public IEnumerable<Product> Products { get; private set; }

        public async Task OnGetAsync()
        {
            Products = await _productService.GetProductsAsync();
        }
    }
}