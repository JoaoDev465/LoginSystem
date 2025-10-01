using Core.Exceptions.UserExceptions;

namespace Core.ValueObject.UserEntityObject;

public class EmailValue:ValueObject
{
    public EmailValue(string value)
    {
        Email = value;

        EmailException.ThrowIfNull(value,"Email is null");
        EmailException.ThrowIfNotContains(value,"Email not Equal '@gmail.com'");
    }

    public string Email { get; } 
}