using System.Text;
using BusinessObject.Entities;
using DataAccessObject.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RazorPages.Utils;
using Repositories.OrderDetails;
using Repositories.Orders;
using Repositories.Products;
using Repositories.SignalR;

namespace RazorPages.Pages;

[Authorize]
public class CheckoutModel(
    IProductRepository productRepository,
    IOrderRepository orderRepository,
    IOrderDetailsRepository orderDetailRepository,
    IHubContext<SignalrServer> hubContext,
    IHttpContextAccessor httpContextAccessor) : PageModel
{
    [BindProperty] public IList<Product> CartListModel { get; set; }

    [BindProperty] public IList<ProductCartModel>? SessionList { get; set; }
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
    }

    public double GetTotalPrice()
    {
        double result = 0;
        var idInSession = httpContextAccessor.HttpContext?.Session?.GetList<ProductCartModel>("Cart")?.Select(x => x.ProductId);
        var inSession = idInSession?.ToList();
        var productList = productRepository.GetAllFormSession(inSession!.ToList()).ToList();
        var productSessionList = httpContextAccessor.HttpContext?.Session?.GetList<ProductCartModel>("Cart").ToList();
        foreach (var item in productSessionList)
        {
            result += productList.FirstOrDefault(x => x.ProductID.Equals(item.ProductId))!.Price * item.Quantity;
        }
        return result;
    }

    public async Task<IActionResult> OnPostCheckOut()
    {
        var now = DateTime.Now;
        var orderIdGuid = Guid.NewGuid();
        var order = new Order()
        {
            userID = User.Claims.FirstOrDefault(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value,
            total = TotalMoney,
            orderID = orderIdGuid,
            status = 0,
            create_At = now,
            note = "Order Note",
            kinhdo = Kinhdo,
            vido = ViDo,
            address = Address
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
        await productRepository.UpdateProductQuantity(sessionCartModels);
        // await hubContext.Clients.All.SendAsync("NewOrder", new OderHistoryModel
        // {
        //     OrderId = orderIdGuid.ToString(),
        //     User_Name = "NguoiMua",
        //     NumOfProduct = sessionCartModels.ToList().Count,
        //     Total = TotalMoney,
        //     Create_At = now,
        //     ShipperName = "NguoiBan"
        // });
        httpContextAccessor.HttpContext?.Session?.SetList("Cart", new List<ProductCartModel>());
        return RedirectToPage("./Menu");
    }


    public IActionResult OnPostCalculateShippingCost([FromBody] DistanceRequest request)
    {
        double distance = request.Distance;
        double shippingCost = CalculateShippingCost(distance);
        double productCost = GetTotalPrice();
        TotalMoney = shippingCost + productCost;
        Kinhdo = request.KinhDo;
        ViDo = request.ViDo;
        Address = request.AddressUser;
        return new JsonResult(new { shippingCost = shippingCost, productCost = productCost, total = TotalMoney });
    }

    private double CalculateShippingCost(double distance)
    {
        // Implement your shipping cost calculation logic here
        // For example, $5 base cost + $1 per km
        return 10000 * (distance * 1);
    }

    public double TotalMoney
    {
        get
        {
            if (HttpContext.Session.TryGetValue("TotalMoney", out byte[] value))
            {
                return JsonConvert.DeserializeObject<double>(Encoding.UTF8.GetString(value));
            }
            return 0;
        }
        set
        {
            HttpContext.Session.Set("TotalMoney", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value)));
        }
    }

    public string Kinhdo
    {
        get
        {
            if (HttpContext.Session.TryGetValue("Kinhdo", out byte[] value))
            {
                return Encoding.UTF8.GetString(value);
            }
            return string.Empty;
        }
        set
        {
            HttpContext.Session.Set("Kinhdo", Encoding.UTF8.GetBytes(value));
        }
    }

    public string ViDo
    {
        get
        {
            if (HttpContext.Session.TryGetValue("ViDo", out byte[] value))
            {
                return Encoding.UTF8.GetString(value);
            }
            return string.Empty;
        }
        set
        {
            HttpContext.Session.Set("ViDo", Encoding.UTF8.GetBytes(value));
        }
    }

    public string Address
    {
        get
        {
            if (HttpContext.Session.TryGetValue("Address", out byte[] value))
            {
                return Encoding.UTF8.GetString(value);
            }
            return string.Empty;
        }
        set
        {
            HttpContext.Session.Set("Address", Encoding.UTF8.GetBytes(value));
        }
    }
}

public class DistanceRequest
{
    public double Distance { get; set; }
    public string KinhDo { get; set; }
    public string ViDo { get; set; }

    public string AddressUser { get; set; }
}