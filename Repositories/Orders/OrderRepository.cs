using BusinessObject.Entities;
using DataAccessObject.Orders;

namespace Repositories.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDAO _dao = new();
        
        public async Task Add(Order order)
        {
            await _dao.AddOrder(order);
        }
    }
}