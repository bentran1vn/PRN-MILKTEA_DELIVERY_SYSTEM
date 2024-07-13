using System.Security.Claims;
using BusinessObject.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Repositories.OrderDetails;
using Repositories.Orders;
using Repositories.SignalR;
namespace RazorPages.Pages;

[Authorize]
public class ShipperOrderDetail(
    IOrderRepository orderRepository,
    IOrderDetailsRepository orderDetailRepository,
    IHubContext<SignalrServer> hubContext,
    IHttpContextAccessor httpContextAccessor) : PageModel
{
    
    [BindProperty] public Order Order { get; set; }
    [BindProperty] public IList<OrderDetail> OrderDetails { get; set; }
    
    [BindProperty] public string OrderId { get; set; }
    
    public void OnGet(string? id)
    {
        Order = orderRepository.GetOrderById(id!);
        OrderDetails = orderDetailRepository.GetOrderDetailByOrderId(id!).ToList();
    }
    
    public IActionResult OnPostHandlerDone()
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
        if (userId != null && role is "3")
        {
            orderRepository.UpdateOrder(new Guid(OrderId), 2, userId);
        }
        return RedirectToPage("./Shipper");
    }
    
}