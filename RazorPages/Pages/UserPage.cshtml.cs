using BusinessObject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Users;

namespace RazorPages.Pages;

public class UserPage(IUserRepository userRepository)  : PageModel
{
    [BindProperty] public IList<User> Users { get; set; }
    
    [BindProperty] public string UserId { get; set; }

    public void OnGet()
    {
        Users = userRepository.GetAll().ToList();
    }

    public async Task<IActionResult> OnPost()
    {
        await userRepository.DeleteUserById(UserId);
        return RedirectToPage("/UserPage");
    }
}