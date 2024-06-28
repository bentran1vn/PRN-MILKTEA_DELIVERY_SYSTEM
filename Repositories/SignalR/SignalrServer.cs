using Microsoft.AspNetCore.SignalR;
using BusinessObject.Entities;
namespace Repositories.SignalR;

public class SignalrServer:Hub
{
    // public async Task NewOrder(BusinessObject.Entities.Order order)
    // {
    //     await Clients.Caller.SendAsync("NewOrder", order);
    // }
}