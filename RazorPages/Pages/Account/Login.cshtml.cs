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
            public string returnUrl { get; set; }
            public void OnGet(string returnUrl =null)
            {
                this.returnUrl = returnUrl;
            }

            public async Task<IActionResult> OnPostAsync(string returnUrl = null)
            {
                // Capture the returnUrl from the query string
                returnUrl = returnUrl ?? Url.Content("~/");

                var user = await _userRepository.Login(Input.userName, Input.password);
                if (user != null)
                {
                    AddRoleClaim(user.roleID, user.userID);

                    // Redirect to the ReturnUrl if it exists
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToPage("/Index");
                    }
                }
                else
                {
                    Message = "Invalid username or password";
                    return Page();
                }
            }


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