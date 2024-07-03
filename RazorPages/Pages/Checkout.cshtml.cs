using BusinessObject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using RazorPages.Utils;
using Repositories.Products;

namespace RazorPages.Pages;

public class Checkout(IProductRepository productRepository,
    IHttpContextAccessor httpContextAccessor) : PageModel
{
    [BindProperty] public IList<Product> CartListModel { get; set; }
    
    [BindProperty] public IList<ProductCartModel>? SessionList { get; set; }
    
    [BindProperty] public double Total { get; set; } = 0;
    public void OnGet()
    {
        var idInSession = httpContextAccessor.HttpContext?.Session?.GetList<ProductCartModel>("Cart")?.Select(x => x.ProductId);
        var inSession = idInSession?.ToList();
        if (inSession.IsNullOrEmpty()) return;
        SessionList = httpContextAccessor.HttpContext?.Session?.GetList<ProductCartModel>("Cart").ToList();
        var result = productRepository.GetAllFormSession(inSession!.ToList()).ToList();
        if (!result.IsNullOrEmpty())
        {
            CartListModel = result;
        }
        Total = GetTotalPrice();
    }
    
    public double GetTotalPrice()
    {
        double result = 0;
        if (SessionList == null) return result;
        foreach (var item in SessionList)
        {
            result += CartListModel.FirstOrDefault(x => x.ProductID.Equals(item.ProductId))!.Price * item.Quantity;
        }
        return result;
    }
}