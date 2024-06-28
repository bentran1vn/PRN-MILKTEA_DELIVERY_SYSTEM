using BusinessObject.Entities;
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
    
    public async Task<IActionResult> OnPostCheckOut()
    {
        var now = DateTime.Now;
        var orderIdGuid = Guid.NewGuid();
        var order = new Order()
        {
            userID = "123123",
            total = Total,
            orderID = orderIdGuid,
            status = 1,
            shipperID = "123125",
            create_At = now,
            note = "Order Note"
        };
        await orderRepository.Add(order);
        List<OrderDetail> orderDetailList = new List<OrderDetail>();
        var sessionCartModels = httpContextAccessor.HttpContext?.Session?.GetList<ProductCartModel>("Cart").ToList();
        foreach (var item in sessionCartModels)
        {
            orderDetailList.Add(new OrderDetail()
            {
                orderID = orderIdGuid,
                quantity = item.Quantity,
                productID = item.ProductId,
                note = "Note"
            });
        }
        await orderDetailRepository.AddOrderDetails(orderDetailList);
        await hubContext.Clients.All.SendAsync("NewOrder", new OderHistoryModel
        {
            OrderId = orderIdGuid.ToString(),
            User_Name = "NguoiMua",
            NumOfProduct = sessionCartModels.ToList().Count,
            Total = productRepository.GetAll().Where(x => sessionCartModels.Select(x => x.ProductId).Contains(x.ProductID)).Select(x => x.Price).Sum(),
            Create_At = now,
            ShipperName = "NguoiBan"
        });
        httpContextAccessor.HttpContext?.Session?.SetList("Cart", new List<ProductCartModel>());
        return RedirectToPage("./Menu");
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