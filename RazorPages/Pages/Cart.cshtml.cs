using BusinessObject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using RazorPages.Utils;
using Repositories.Products;

namespace RazorPages.Pages;

public class Cart : PageModel
{
    
    private readonly IProductRepository _productRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public Cart(IProductRepository productRepository, IHttpContextAccessor httpContextAccessor)
    {
        _productRepository = productRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    [BindProperty] public IList<Product> CartListModel { get; set; }
    [BindProperty] public IList<ProductCartModel>? SessionList { get; set; }

    [BindProperty] public double Total { get; set; } = 0;

    public void OnGet()
    {
        var idInSession = _httpContextAccessor.HttpContext?.Session?.GetList<ProductCartModel>("Cart")?.Select(x => x.ProductId);
        var inSession = idInSession?.ToList();
        if (inSession.IsNullOrEmpty()) return;
        SessionList = _httpContextAccessor.HttpContext?.Session?.GetList<ProductCartModel>("Cart").ToList();
        var result = _productRepository.GetAllFormSession(inSession!.ToList()).ToList();
        if (!result.IsNullOrEmpty())
        {
            CartListModel = result;
        }
        Total = GetTotalPrice();
    }
    
    public IActionResult OnPostRemoveProduct(string productId)
    {
        // Implement logic to remove Product 1 from the cart
        _httpContextAccessor.HttpContext?.Session.RemoveProductFromCart(productId);
        return RedirectToPage("/Cart");
    }

    public double GetTotalPrice()
    {
        double result = 0;
        if (SessionList == null) return result;
        foreach (var item in SessionList)
        {
            result += CartListModel.FirstOrDefault(x => x.productID.Equals(item.ProductId))!.price * item.Quantity;
        }
        return result;
    }
}