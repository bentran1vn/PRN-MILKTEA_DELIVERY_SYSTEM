using BusinessObject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using Repositories.Products;

namespace RazorPages.Pages;

public class Menu : PageModel
{
    private readonly IProductRepository _productRepository;

    public Menu(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    [BindProperty] public IList<Product> ProductList { set; get; }

    [BindProperty] public int TotalProPage { set; get; }

    [BindProperty] public string Keyword { set; get; }

    public void OnGet(string keyword, string? pageNum = "1", string pageSize = "9")
    {
        Keyword = keyword;
        if (!Int32.TryParse(pageNum, out int pageNumInt)) return;
        if (string.IsNullOrEmpty(Keyword))
        {
            ProductList = _productRepository.GetAll(pageNumInt, 9).ToList();
            int count = _productRepository.GetCount();
            int result = (int)Math.Ceiling(count / 9.0);
            TotalProPage = result;
        }
        else
        {
            ProductList = _productRepository.Search(Keyword, pageNumInt, 9).ToList();
            int count = _productRepository.GetCountBySearch(Keyword);
            int result = (int)Math.Ceiling(count / 9.0);
            TotalProPage = result;
        }
    }
}