using BusinessObject;
using BusinessObject.Entities;
using Microsoft.EntityFrameworkCore;

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

        public IEnumerable<Order> GetAllOrder(int? status)
        {
            if (status == null)
            {
                return _context.Orders.AsNoTracking();
            }
            else
            {
                return _context.Orders.Include(o => o.Users).AsNoTracking().Where(o => o.status == status);
            }
        }

        public Order? GetOrder(string? id)
        {
            return _context.Orders.FirstOrDefault(o => o.orderID.Equals(new Guid(id)));
        }

        public void UpdateOrder(Guid? id, int status, string shipperId)
        {
            var order = _context.Orders.FirstOrDefault(o => o.orderID.Equals(id));
            order!.status = status;
            order!.shipperID = shipperId;
            _context.Orders.Update(order);
            _context.SaveChanges();
        }


        public IEnumerable<Order> GetOrders(string userID)
        {
            var orders = _context.Orders.Include(o => o.Users).Where(o => o.userID == userID && o.status != 0).ToList();
            foreach (var order in orders)
            {
                try
                {
                    order.Shippers = _context.Users.FirstOrDefault(u => u.userID == order.shipperID);
                }
                catch (Exception e)
                {

                }

            }
            return orders;
        }
    }
};

