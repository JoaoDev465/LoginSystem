using Core.Exceptions.UserExceptions;

namespace Core.ValueObject;

public class PasswordValue:ValueObject
{
    public PasswordValue(string password)
    {
        Password = password;
        PasswordException.ThrowIsNull(password,"Password is null");
    }
    public string  Password { get; set; }
}