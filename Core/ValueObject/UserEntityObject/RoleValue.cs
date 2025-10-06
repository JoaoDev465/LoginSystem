using Core.Exceptions.UserExceptions;

namespace Core.ValueObject.UserEntityObject;

public class RoleValue: ValueObject
{
    public RoleValue(string[]? value)
    {
        Role = value;
        
        RoleException.ThrowIsNull(value,"Role is null");
    }

    public string[]? Role { get; set; }
}