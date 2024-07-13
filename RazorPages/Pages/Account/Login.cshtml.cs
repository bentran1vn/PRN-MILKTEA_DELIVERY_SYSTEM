using BusinessObject.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Repositories.Users;

namespace RazorPages.Pages.Account
{
    [AllowAnonymous]

    public class LoginModel(IUserRepository userRepository) : PageModel
    {
        private readonly IUserRepository _userRepository = userRepository;

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public User Input { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/");
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            var user = await _userRepository.Login(Input.userName, Input.password);
            if (user != null)
            {
                AddRoleClaim(user.roleID, user.userID);
                if (user.roleID == 1) // Example role for admin
                {
                    returnUrl = Url.Page("/Admin");
                }
                else if (user.roleID == 2) // Example role for shipper
                {
                    returnUrl = Url.Page("/");
                }
                else if (user.roleID == 3) // Example role for shipper
                {
                    returnUrl = Url.Page("/Shipper");
                }
                else
                {
                    returnUrl = Url.Content("~/");
                }

                return LocalRedirect(returnUrl);



        private void AddRoleClaim(int role, string userID)
        {
            var claims = new List<Claim>
            {
                new("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", role.ToString()),
                new("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", userID.ToString())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
    }
}