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
    
    [BindProperty] public int TotalProPage { set; get; }

    [BindProperty] public int CurrentPage { set; get; } = 1;

    public void OnGet(string? pageNum = "1", string pageSize = "9")
    {
        if (!Int32.TryParse(pageNum, out int pageNumInt)) return;
        ProductList = _productRepository.GetAll(pageNumInt, 9).ToList();
        int count = _productRepository.GetCount();
        int result = (int)Math.Ceiling(count / 9.0);
        TotalProPage = result;
    }
}