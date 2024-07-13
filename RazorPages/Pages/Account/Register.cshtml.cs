using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Users;

namespace RazorPages.Pages.Account
{
    public class RegisterModel(IUserRepository userRepository) : PageModel
    {
        [BindProperty]
        public RegisterInputModel Input { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                userRepository.CreateUser(Input.UserName, Input.Password, Input.Email, Input.PhoneNumber, Input.Address, Input.Yob, 1);
                Message = "Registration successful!";
                return RedirectToPage("./Login");
            }
            catch (Exception e)
            {

                Message = e.Message;
            }
            
            return Page();
        }
    }

    public class RegisterInputModel
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Year of Birth")]
        [DataType(DataType.Date)]
        public DateTime Yob { get; set; }
    }
};