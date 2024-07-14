using System.Security.Claims;
using System.Text;
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
        if (IsTaked == String.Empty)
        {
            Orders = orderRepository.GetAllOrder(0).ToList();
        }
        else if(IsTaked != String.Empty)
        {
            Orders = orderRepository.GetAllOrder(1).Where(o => o.orderID.Equals(new Guid(IsTaked))).ToList();
        }
    }
    
    public async Task<IActionResult> OnPostHandlerTake()
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
        if (userId != null && role is "3")
        {
            orderRepository.UpdateOrder(new Guid(OrderId), 1, userId);
            IsTaked = OrderId;
        }
        await hubContext.Clients.All.SendAsync("NewStatus");
        return RedirectToPage("./Shipper");
    }
    
    public string IsTaked
    {
        get
        {
            if (HttpContext.Session.TryGetValue("IsTaked", out byte[] value))
            {
                return Encoding.UTF8.GetString(value);
            }
            return string.Empty;
        }
        set
        {
            HttpContext.Session.Set("IsTaked", Encoding.UTF8.GetBytes(value));
        }
    }
}