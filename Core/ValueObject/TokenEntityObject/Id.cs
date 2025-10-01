namespace Core.ValueObject.TokenEntityObject;

public class IdValue
{
    public IdValue(int value)
    {
        Value = value;
    }
    public int Value { get; set; }
}