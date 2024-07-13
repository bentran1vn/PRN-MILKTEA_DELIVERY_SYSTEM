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

        public IEnumerable<Order> GetAllOrder(int? status)
        {
            return  _dao.GetAllOrder(status).OrderBy(o => o.create_At);
        }

        public Order GetOrderById(string id)
        {
            return _dao.GetOrder(id);
        }


        public IEnumerable<Order> GetOrders(string userID)
        {
            return _dao.GetOrders(userID);
        }

      

        public void UpdateOrder(Guid id, int status, string shipperId)

        { 
            _dao.UpdateOrder(id, status, shipperId);
        }
    }
}