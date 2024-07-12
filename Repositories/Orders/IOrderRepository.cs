using BusinessObject.Entities;

namespace Repositories.Orders
{
    public interface IOrderRepository
    {
        Task Add(Order order);

        IEnumerable<Order> GetAllOrder(int? status);

        Order GetOrderById(string id);

        void UpdateOrder(Guid id, int status);

        IEnumerable<Order> GetOrders(string userID);
    }
};

