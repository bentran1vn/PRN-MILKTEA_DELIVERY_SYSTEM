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
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Configuration;

namespace RazorPages.Pages
{
    public class VoucherAddNewPageModel(IVoucherRepository _voucherRepository) : PageModel
    {

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public VoucherModel Voucher { get; set; }

        [BindProperty]
        public string msg { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                msg = "Missing information";
            }

            Voucher addVoucher = new Voucher()
            {
                voucherID = Guid.NewGuid().ToString(),
                voucherName = Voucher.voucherName,
                description = Voucher.description,
                amount = Voucher.amount,
                min = Voucher.min,
                quantity = Voucher.quantity,
                status = true,
            };

            //Voucher.create_By = null;
            msg = await _voucherRepository.Add(addVoucher);
            return Page();
        }
    }

    public class VoucherModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Voucher name must contain only letters and spaces.")]
        public required string voucherName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Description must contain only letters and spaces.")]
        public required string description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be a positive value.")]
        public required double amount { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Minimum must be a positive value.")]
        public required double min { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 1.")]
        public required int quantity { get; set; }
    }
}
