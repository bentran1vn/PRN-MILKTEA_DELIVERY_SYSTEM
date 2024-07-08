using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using BusinessObject.Entities;
using Repositories.Voucher;

namespace RazorPages.Pages
{
    public class VoucherAddNewPageModel(IVoucherRepository _voucherRepository) : PageModel
    {
        
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Voucher Voucher { get; set; }

        [BindProperty]
        public string msg { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                msg = "Missing information";
            }
            
            Voucher.voucherID = Guid.NewGuid().ToString();
            Voucher.status = true;
            //Voucher.create_By = null; 
            msg = await _voucherRepository.Add(Voucher);
            return Page();
        }
    }
}
