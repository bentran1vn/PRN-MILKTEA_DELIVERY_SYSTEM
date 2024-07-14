using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using BusinessObject.Entities;
using Repositories.Voucher;

namespace RazorPages.Pages
{
    public class VoucherEditModel(IVoucherRepository _voucherRepository) : PageModel
    {

        [BindProperty]
        public BusinessObject.Entities.Voucher Voucher { get; set; }
        [BindProperty] public string Msg {  get; set; }

        public void OnGetAsync(string id)
        {
            Voucher = _voucherRepository.GetVoucher(id);
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public void OnPostAsync()
        {
            Msg = _voucherRepository.Update(Voucher);
        }
    }
}
