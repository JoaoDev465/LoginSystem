namespace Core.ValueObject.TokenEntityObject;

public class TokenRefresh : ValueObject
{
    public TokenRefresh(string value)
    {
        Value = value;
    }

    public string Value { get; set; }

    public override string ToString() => Value;
}