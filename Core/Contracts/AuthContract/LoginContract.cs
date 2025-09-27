using System.ComponentModel.DataAnnotations;

namespace Core.Contracts.AuthContract;

public class LoginContract
{
    [Required]
    public string Password { get; set; }
    [Required]
    public string Email { get; set; }
}