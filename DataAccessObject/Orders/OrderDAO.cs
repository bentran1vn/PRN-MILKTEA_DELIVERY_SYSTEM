using BusinessObject;
using BusinessObject.Entities;

namespace DataAccessObject.Orders
{
    public class OrderDAO
    {
        private MilkTeaDeliveryDBContext _context = new();

        public async Task AddOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }
    
    }
};

