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
        var test = _context.OrderDetails.Include(od => od.Products).Where(od => od.orderID.Equals(new Guid(orderId!))).ToList();
        return test;
    }

    public IEnumerable<Guid> GetOrderDetailIDsFromOrderID(string orderID)
    {
        var list = _context.OrderDetails.Where(od => od.orderID.ToString()==orderID).Select(od => od.Id).ToList();
        return list;
    }
    
}