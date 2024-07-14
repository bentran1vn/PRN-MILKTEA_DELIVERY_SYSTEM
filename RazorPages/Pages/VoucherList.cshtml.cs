using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using BusinessObject.Entities;

namespace RazorPages.Pages
{
    public class VoucherListModel : PageModel
    {
        private readonly MilkTeaDeliveryDBContext _context;

        public VoucherListModel(MilkTeaDeliveryDBContext context)
        {
            _context = context;
        }

        public IList<BusinessObject.Entities.Voucher> Voucher { get; set; }

        public async Task OnGetAsync()
        {
            Voucher = await _context.Vouchers.ToListAsync();
        }
    }
}
