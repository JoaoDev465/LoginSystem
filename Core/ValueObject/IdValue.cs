namespace Core.ValueObject;

public class IdValue: ValueObject
{
    public IdValue(int id)
    {
        Id = id;
    }
    public int Id{ get; set; }
}