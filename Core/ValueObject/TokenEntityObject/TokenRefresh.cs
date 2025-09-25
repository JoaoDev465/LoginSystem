using Core.Exceptions.TokenExceptions;

namespace Core.ValueObject.TokenEntityObject;

public class TokenRefresh : ValueObject
{
    public TokenRefresh(string value)
    {
        Value = value;
        TokenRefreshException.ThrowRefreshNull(value,"Token can't be null");
    }

    public string Value { get; set; }

    public override string ToString() => Value;
}