using System.ComponentModel.DataAnnotations;
using Core.Contracts.UserContract;

namespace Core.Contracts.AuthContract;

public class LoginContract
{
    [Required(ErrorMessage = "Email row is required")]
    [EmailAddress]
    [EmailValidation]
    public string Email{ get; set; }
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$&])([A-Za-z\d!@#$&]){8,}")]
    [Required(ErrorMessage = "Password row is required")]
    public string Password { get; set; }
}
