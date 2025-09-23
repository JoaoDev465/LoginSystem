using Core.Exceptions.UserExceptions;

namespace Core.ValueObject.EntityObject;

public class NameValue: ValueObject
{
   public NameValue(string name)
   {
      Name = name;
      
      NameException.ThrowIfNull(name, "Name is Null");
   }

   public string Name { get; }
}