using BusinessObject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Orders;

namespace RazorPages.Pages;

public class OrderHistory : PageModel
{

    private readonly IOrderRepository _orderRepository;

    [BindProperty]
    public IEnumerable<Order> Order { get; set; }
    public OrderHistory(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public void OnGet()
    {
        Order = _orderRepository.GetAllOrders().OrderByDescending(x => x.create_At);
    }
}