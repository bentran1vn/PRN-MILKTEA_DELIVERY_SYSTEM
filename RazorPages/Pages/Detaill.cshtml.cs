using System.Collections;
using BusinessObject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Utils;
using Repositories.Products;

namespace RazorPages.Pages;

public class Detaill : PageModel
{
    private readonly IProductRepository _productRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public Detaill(IProductRepository productRepository, IHttpContextAccessor httpContextAccessor)
    {
        _productRepository = productRepository;
        _httpContextAccessor = httpContextAccessor;
    }
    
    [BindProperty] 
    public Product ProductModel { set; get; }
    
    [BindProperty] 
    public ProductCartModel ProductCartInput { set; get; }
    
    [BindProperty] 
    public IList<Product> ProductList4 { set; get; }

    public IActionResult OnGet(string? id)
    {
        if (id == null) RedirectToPage("./Index");
        var result = _productRepository.GetProductById(id!);
        var result4 = _productRepository.GetAll4(id!).ToList();
        if(result == null) RedirectToPage("./Index");
        ProductModel = result!;
        ProductList4 = result4;
        ProductCartInput = new ProductCartModel()
        {
            ProductId = result!.productID
        };
        return Page();
    }
    
    public IActionResult OnPost()
    {
        _httpContextAccessor?.HttpContext?.Session.AddProductToCart(ProductCartInput.ProductId, ProductCartInput.Quantity);
        return RedirectToPage("./Detaill", new { id = ProductCartInput.ProductId });
    }
}