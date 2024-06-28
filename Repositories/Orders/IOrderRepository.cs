using BusinessObject.Entities;

namespace Repositories.Orders
{
    public interface IOrderRepository
    {
        Task Add(Order order);
    }
};

