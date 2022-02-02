using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PasswordHasherDemo.Models;
using System.ComponentModel.DataAnnotations;

namespace PasswordHasherDemo.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IPasswordHasher<User> _passwordHasher;
    public IndexModel(ILogger<IndexModel> logger, IPasswordHasher<User> passwordHasher)
    {
        _logger = logger;
        _passwordHasher = passwordHasher;
    }

    [BindProperty,DataType(DataType.Password)]
    public string Password { get; set; }
    [BindProperty,Display(Name ="User Name")]
    public string UserName { get; set; }
    [BindProperty,HiddenInput]
    public string? HashedPassword { get; set; }
    public string Result { get; set; }
    public void OnPost()
    {
        if (string.IsNullOrEmpty(HashedPassword))
        {
            HashedPassword = _passwordHasher.HashPassword(new User(), Password);
        }
        else
        {
            Result = _passwordHasher.VerifyHashedPassword(new User(), HashedPassword, Password).ToString();
        }
    }
}