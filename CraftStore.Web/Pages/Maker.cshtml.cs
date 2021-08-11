using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraftStore.Web.Models;
using CraftStore.Web.Services;
using CraftStore.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CraftStore.Web.Pages
{
    public class MakerModel : PageModel
    {
        private readonly IProductService _productService;

        public MakerModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        public IEnumerable<Product> Products { get; set; }

        public async Task OnGetAsync()
        {
            Products = await _productService.GetMakerProductsAsync(Name);
        }
    }
}
