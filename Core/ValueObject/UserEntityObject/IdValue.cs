namespace Core.ValueObject.UserEntityObject;

public class IdValue: ValueObject
{
    public IdValue(int value)
    {
        Value = value;
    }
    public int Value{ get; set; }
}