using BusinessObject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Repositories.OrderDetails;
using Repositories.Orders;
using Repositories.SignalR;

namespace RazorPages.Pages;

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
        orderRepository.UpdateOrder(new Guid(OrderId), 2);
        return RedirectToPage("./Shipper");
    }
    
}