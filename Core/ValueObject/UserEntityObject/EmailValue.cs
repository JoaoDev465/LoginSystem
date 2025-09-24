using Core.Exceptions.UserExceptions;

namespace Core.ValueObject.EntityObject;

public class EmailValue:ValueObject
{
    public EmailValue(string email)
    {
        Email = email;

        EmailException.ThrowIfNull(email,"Email is null");
        EmailException.ThrowIfNotContains(email,"Email not Equal '@gmail.com'");
    }

    public string Email { get; } 
}