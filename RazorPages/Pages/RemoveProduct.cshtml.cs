using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using BusinessObject.Entities;
using Repositories.Products;

namespace RazorPages.Pages
{
    public class RemoveProductModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public RemoveProductModel(IProductRepository productRepository)
        {

            _productRepository = productRepository;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = _productRepository.GetProductById(id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = _productRepository.GetProductById(id);

            if (Product != null)
            {
                _productRepository.DeleteProduct(Product.ProductID);
                
            }

            return RedirectToPage("./ProductManagePage");
        }
    }
}
