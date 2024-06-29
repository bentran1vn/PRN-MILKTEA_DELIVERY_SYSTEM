using BusinessObject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Products;

namespace RazorPages.Pages;

public class ProductManagePage(IProductRepository productRepository) : PageModel
{
    [BindProperty] public IList<Product> ProductList { set; get; }
    [BindProperty] public int TotalProPage { set; get; }
    [BindProperty] public int PageNum { set; get; }
    
    public void OnGet(string? pageNum = "1", string pageSize = "8")
    {
        if (!Int32.TryParse(pageNum, out int pageNumInt)) return;
        if (!Int32.TryParse(pageSize, out int pageSizeInt)) return;
        PageNum = pageNumInt;
        ProductList = productRepository.GetAllDes(pageNumInt, pageSizeInt).ToList();
        int count = productRepository.GetCount();
        int result = (int)Math.Ceiling(count / 8.0);
        TotalProPage = result;
    }
}