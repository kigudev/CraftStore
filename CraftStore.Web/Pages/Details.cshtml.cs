using CraftStore.Web.Models;
using CraftStore.Web.Services;
using CraftStore.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CraftStore.Web.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IDbProductService _productService;

        public DetailsModel(IDbProductService productService)
        {
            _productService = productService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public Product Product { get; set; }

        public async Task OnGetAsync()
        {
            Product = await _productService.GetProductAsync(Id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _productService.DeleteProductAsync(Id);
            return RedirectToPage("/Index");
        }
    }
}