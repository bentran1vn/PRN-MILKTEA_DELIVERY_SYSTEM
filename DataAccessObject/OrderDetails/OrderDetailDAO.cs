using BusinessObject;
using BusinessObject.Entities;

namespace DataAccessObject.OrderDetails;

public class OrderDetailDAO
{
    private MilkTeaDeliveryDBContext _context = new();
    
    public async Task AddOrderDetails(IEnumerable<OrderDetail> orderDetails)
    {
        await _context.OrderDetails.AddRangeAsync(orderDetails);
        await _context.SaveChangesAsync();
    }
}