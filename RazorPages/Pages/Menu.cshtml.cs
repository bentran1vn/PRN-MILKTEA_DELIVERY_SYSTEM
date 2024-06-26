using BusinessObject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Products;

namespace RazorPages.Pages;

public class Menu : PageModel
{
    private readonly IProductRepository _productRepository;

    public Menu( IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    [BindProperty] public IList<Product> ProductList { set; get; }
    public void OnGet()
    {
        ProductList = _productRepository.GetAll6().ToList();
    }
}