using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraftStore.Web.Models;
using CraftStore.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CraftStore.Web.Pages
{
    public class MakerModel : PageModel
    {
        private readonly JsonFileProductService _productService;

        public MakerModel(JsonFileProductService productService)
        {
            _productService = productService;
        }

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        public IEnumerable<Product> Products { get; set; }

        public void OnGet()
        {
            Products = _productService.GetMakerProducts(Name);
        }
    }
}
