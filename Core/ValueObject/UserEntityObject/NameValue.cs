using Core.Exceptions.UserExceptions;

namespace Core.ValueObject.UserEntityObject;

public class NameValue: ValueObject
{
   public NameValue(string value)
   {
      Name = value;
      
      NameException.ThrowIfNull(value, "Name is Null");
   }

   public string Name { get; }
}