using Core.Exceptions.UserExceptions;

namespace Core.ValueObject;

public class EmailValue:ValueObject
{
    public EmailValue(string email)
    {
        Email = email;

        EmailException.ThrowIfNull(email);
        EmailException.ThrowIfNotContains(email,"Email not Equal '@gmail.com'");
    }

    public string Email { get; } 
}