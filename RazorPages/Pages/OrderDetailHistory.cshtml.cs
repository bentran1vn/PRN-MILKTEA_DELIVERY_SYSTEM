using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using BusinessObject.Entities;
using Repositories.OrderDetails;

namespace RazorPages.Pages
{
    public class OrderDetailHistoryModel : PageModel
    {
        private readonly IOrderDetailsRepository _context;

        public OrderDetailHistoryModel(IOrderDetailsRepository context)
        {
            _context = context;
        }

        [BindProperty]
        public IEnumerable<OrderDetail> orderDetails { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            orderDetails = _context.GetOrderDetailByOrderId(id.ToString()).ToList();

            if (orderDetails == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
