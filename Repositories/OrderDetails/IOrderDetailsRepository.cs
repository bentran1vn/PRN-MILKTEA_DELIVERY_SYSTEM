using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Entities;

namespace Repositories.OrderDetails
{
    public interface IOrderDetailsRepository
    {
        Task AddOrderDetails(IEnumerable<OrderDetail> orderDetails);

        IEnumerable<OrderDetail> GetOrderDetailByOrderId(string? id);

        IEnumerable<Guid> GetOrderDetailIDsFromOrderID(string orderID);

       

    }
};


