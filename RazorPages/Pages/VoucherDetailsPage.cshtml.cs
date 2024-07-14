using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using BusinessObject.Entities;
using Repositories.Voucher;

namespace RazorPages.Pages
{
    public class VoucherDetailsModel(IVoucherRepository _voucherRepository) : PageModel
    {

        public Voucher Voucher { get; set; }

        public void OnGetAsync(string id)
        {
            Voucher = _voucherRepository.GetVoucher(id);
        }
    }
}
