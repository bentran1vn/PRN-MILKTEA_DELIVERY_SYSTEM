using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Entities;
using DataAccessObject.OrderDetails;

namespace Repositories.OrderDetails;

public class OrderDetailsRepository : IOrderDetailsRepository
{
    private readonly OrderDetailDAO _dao = new();
    public async Task AddOrderDetails(IEnumerable<OrderDetail> orderDetails)
    {
        await _dao.AddOrderDetails(orderDetails);
    }

    public IEnumerable<OrderDetail> GetOrderDetailByOrderId(string? id)
    {
        return _dao.GetOrderDetailByOrderId(id);
    }

    public IEnumerable<Guid> GetOrderDetailIDsFromOrderID(string orderID)
    {
       return _dao.GetOrderDetailIDsFromOrderID(orderID);
    }
}
