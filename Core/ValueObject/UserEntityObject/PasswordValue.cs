using Core.Exceptions.UserExceptions;

namespace Core.ValueObject.UserEntityObject;

public class PasswordValue:ValueObject
{
    public PasswordValue(string value)
    {
        Password = value;
        PasswordException.ThrowIsNull(value,"Password is null");
    }
    public string  Password { get;}
}