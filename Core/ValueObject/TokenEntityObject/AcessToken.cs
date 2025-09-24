namespace Core.ValueObject.TokenEntityObject;

public class AcessToken : ValueObject
{
    public AcessToken(string value)
    {
        Value = value;
    }
    public string Value{ get; set; }

    public override string ToString() => Value;
}