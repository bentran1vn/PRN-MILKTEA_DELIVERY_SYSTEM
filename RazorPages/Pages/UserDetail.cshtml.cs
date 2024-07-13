using BusinessObject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Users;

namespace RazorPages.Pages;

public class UserDetail(IUserRepository userRepository) : PageModel
{
    
    [BindProperty] public User? UserModel { get; set; } 
    [BindProperty] public InputModel? Input { get; set; } 
    
    public async Task<IActionResult> OnGetAsync(string id)
    {
        var result = await userRepository.GetUserById(id);
        if (result != null)
        {
            UserModel = result;
            Input = new InputModel
            {
                userId = result.userID,
                userName = result.userName,
                address = result.address,
                password = result.password,
                phoneNumber = result.phoneNumber,
                yob = result.yob
            };
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var userToUpdate = await userRepository.GetUserById(Input.userId);
        if (userToUpdate != null)
        {
            userToUpdate.userName = Input.userName;
            userToUpdate.address = Input.address;
            userToUpdate.password = Input.password;
            userToUpdate.phoneNumber = Input.phoneNumber;
            userToUpdate.yob = Input.yob;

            await userRepository.UpdateUser(userToUpdate);
        }

        return RedirectToPage("./UserPage");
    }
}

public class InputModel
{   
    public string userId {  get; set; }
    public string userName {  get; set; }
    public string password { get; set; }
    public string phoneNumber { get; set; }
    public string address { get; set; }
    public DateTime yob { get; set; }
}