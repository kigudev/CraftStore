using CraftStore.Web.Models;
using CraftStore.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CraftStore.Web.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly JsonFileProductService _productService;

        public DetailsModel(JsonFileProductService productService)
        {
            _productService = productService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public Product Product { get; set; }

        public void OnGet()
        {
            Product = _productService.GetProduct(Id);
        }
    }
}