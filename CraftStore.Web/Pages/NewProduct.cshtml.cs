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
    public class NewProductModel : PageModel
    {
        private readonly IDbProductService _productService;

        public NewProductModel(IDbProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public Product Product { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // hay que validar si el id ya está repetido en la base de datos
                // si no va a tirar una excepción de conflicto de llaves
                var products = await _productService.GetProductsAsync();
                if(products.Any(c => c.Id == Product.Id))
                {
                    ModelState.AddModelError(string.Empty, "El Id ya está siendo usado");
                    return Page();
                }

                await _productService.AddProductAsync(Product);
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
