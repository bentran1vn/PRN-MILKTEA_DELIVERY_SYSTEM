using BusinessObject.Entities;
using DataAccessObject.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using RazorPages.Utils;
using Repositories.OrderDetails;
using Repositories.Orders;
using Repositories.Products;
using Repositories.SignalR;

namespace RazorPages.Pages;

public class Cart(
    IProductRepository productRepository,
    IHttpContextAccessor httpContextAccessor,
    IHubContext<SignalrServer> hubContext,
    IOrderRepository orderRepository,
    IOrderDetailsRepository orderDetailRepository)
    : PageModel
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
    
    public IActionResult OnPostRemoveProduct(string productId)
    {
        httpContextAccessor.HttpContext?.Session.RemoveProductFromCart(productId);
        return RedirectToPage("/Cart");
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

public class OderHistoryModel
{
    public string OrderId { set; get; }
    public string User_Name { set; get; }
    public int NumOfProduct { set; get; }
    public double Total { set; get; }
    public string ShipperName { set; get; }
    public DateTime Create_At { set; get; }
}