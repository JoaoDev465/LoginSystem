using Core.Exceptions.TokenExceptions;

namespace Core.ValueObject.TokenEntityObject;

public class AcessToken : ValueObject
{
    public AcessToken(string value)
    {
        Value = value;
        AccessTokenException.ThrowAccessTokenIsNull(value,"token can't be null");
    }
    public string Value{ get; set; }

    public override string ToString() => Value;
}