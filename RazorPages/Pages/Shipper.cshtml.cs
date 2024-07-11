using BusinessObject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Repositories.Orders;
using Repositories.SignalR;

namespace RazorPages.Pages;

public class Shipper(
    IOrderRepository orderRepository,
    IHubContext<SignalrServer> hubContext,
    IHttpContextAccessor httpContextAccessor) : PageModel
{
    [BindProperty] public IList<Order> Orders { get; set; }
    
    [BindProperty] public string OrderId { get; set; }

    public void OnGet()
    {
        Orders = orderRepository.GetAllOrder(0).ToList();
    }
    
    public IActionResult OnPostHandlerTake()
    {
        orderRepository.UpdateOrder(new Guid(OrderId), 2);
        return Page();
    }
}