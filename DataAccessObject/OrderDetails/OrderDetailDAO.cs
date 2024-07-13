using BusinessObject;
using BusinessObject.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObject.OrderDetails;

public class OrderDetailDAO
{
    private MilkTeaDeliveryDBContext _context = new();
    
    public async Task AddOrderDetails(IEnumerable<OrderDetail> orderDetails)
    {
        await _context.OrderDetails.AddRangeAsync(orderDetails);
        await _context.SaveChangesAsync();
    }

    public IEnumerable<OrderDetail> GetOrderDetailByOrderId(string? orderId)
    {
        return _context.OrderDetails.Include(od => od.Products).Where(od => od.orderID.Equals(new Guid(orderId!)));
    }

    public IEnumerable<Guid> GetOrderDetailIDsFromOrderID(string orderID)
    {
        var list = _context.OrderDetails.Where(od => od.orderID.ToString()==orderID).Select(od => od.Id).ToList();
        return list;
    }
    
}