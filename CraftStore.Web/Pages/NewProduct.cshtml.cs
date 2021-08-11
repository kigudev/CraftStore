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

        public async Task OnPostAsync()
        {
            await _productService.AddProduct(Product);
        }
    }
}
