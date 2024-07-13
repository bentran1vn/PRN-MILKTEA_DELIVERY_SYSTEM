using System.Security.Claims;
using BusinessObject.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Repositories.Orders;
using Repositories.SignalR;

namespace RazorPages.Pages;

[Authorize]
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
        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
        if (userId != null && role is "3")
        {
            orderRepository.UpdateOrder(new Guid(OrderId), 2, userId);
        }
        return RedirectToPage("./Shipper");
    }
}