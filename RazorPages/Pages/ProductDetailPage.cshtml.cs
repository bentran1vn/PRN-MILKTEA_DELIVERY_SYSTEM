using BusinessObject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Products;

namespace RazorPages.Pages;

public class ProductDetailPage(IProductRepository productRepository) : PageModel
{
    
    [BindProperty] public Product ProductModel { set; get; }
    [BindProperty] public IFormFile FileUpload { set; get; }
    
    public IActionResult OnGet(string? id)
    {
        if (id != null)
        {
            ProductModel = productRepository.GetProductById(id);
            return Page();
        }

        return RedirectToPage("./ProductManagePage");
    }
    
    public IActionResult OnPostRemoveProduct(string productId)
    {
        Console.WriteLine(productId);
        productRepository.DeleteProduct(productId);
        return RedirectToPage("./ProductManagePage");
    }
}