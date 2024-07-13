using BusinessObject.Entities;
using DataAccessObject.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Orders;
using System.Security.Claims;

namespace RazorPages.Pages;

[Authorize]
public class OrderFeebBackModel : PageModel
{
    private readonly IOrderRepository _orderRepository;

    public OrderFeebBackModel(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    [BindProperty] public IEnumerable<Order> Order { get; set; }

    public void OnGet()
    {
        var userIdClaim = User.Claims.FirstOrDefault(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
        Order = _orderRepository.GetOrders(userIdClaim);
    }
}
