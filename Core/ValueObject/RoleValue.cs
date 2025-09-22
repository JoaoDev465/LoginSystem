using Core.Exceptions.UserExceptions;

namespace Core.ValueObject;

public class RoleValue: ValueObject
{
    public RoleValue(string[] role)
    {
        Role = role;
        
        RoleException.ThrowIsNull(role,"Role is null");
    }

    public string[] Role { get; set; }
}