using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PasswordHasherDemo.Models;
using System.ComponentModel.DataAnnotations;

namespace PasswordHasherDemo.Pages;
public class IndexModel : PageModel
{
    private readonly IPasswordHasher<User> _passwordHasher;
    public IndexModel(IPasswordHasher<User> passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    [BindProperty,Required,DataType(DataType.Password)]
    public string Password { get; set; }
    [BindProperty,Required,Display(Name ="User Name")]
    public string UserName { get; set; }
    [BindProperty,HiddenInput]
    public string HashedPassword { get; set; }
    public string Result { get; set; }
    public void OnPost()
    {
        if (ModelState.IsValid)
        {
            var user = new User { UserName = UserName };
            if (string.IsNullOrEmpty(HashedPassword))
            {
                HashedPassword = _passwordHasher.HashPassword(user, Password);
                Result = "Password has been hashed. Please sign in.";
            }
            else
            {
                Result = _passwordHasher.VerifyHashedPassword(user, HashedPassword, Password).ToString();
            }
        }
    }
}