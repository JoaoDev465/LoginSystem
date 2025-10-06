using System.ComponentModel.DataAnnotations;

namespace Core.Contracts.AuthContract;

public class RegisterContract
{
    public int Id { get; set; } = 0;

    [Required(ErrorMessage = "name's row can't be null")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "The Field Email can't be null")]
    [EmailAddress] 
    [EmailValidation] 
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Password can't be null")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[!@#$&])(?=.*\d)([A-Za-z!@#$&\d]){8,}$",
        ErrorMessage = "Password must contain 8 characters,1 especial character ex: !@#$%&," +
                       "1 long word,1 small word and 1 number")]
    public string Password { get; set; } = null!;

    public string[]? Roles { get; set; }
}

public class EmailValidation : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        string? email = value as string;
        if (string.IsNullOrEmpty(email))
            return new ValidationResult(ErrorMessage = "Email's can't be bull");

        if (!email.EndsWith("@gmail.com"))
            return new ValidationResult(ErrorMessage = "Email's row must have a '@gmail.com'");
        
        return ValidationResult.Success;
    }
}