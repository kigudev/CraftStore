using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraftStore.Web.Models;
using CraftStore.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CraftStore.Web.Pages
{
    public class EditProductModel : PageModel
    {
        private readonly IDbProductService _productService;

        public EditProductModel(IDbProductService productService)
        {
            _productService = productService;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        [BindProperty]
        public Product Product { get; set; }
        public async Task OnGetAsync()
        {
            Product = await _productService.GetProductAsync(Id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await _productService.UpdateProductAsync(Product);
               
                return RedirectToPage("/index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Hay datos inválidos en tu información");
                return Page();
            }
        }
    }
}
