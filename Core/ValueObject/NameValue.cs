using Core.Exceptions.UserExceptions;

namespace Core.ValueObject;

public class NameValue: ValueObject
{
   public NameValue(string name)
   {
      Name = name;
      
      NameException.ThrowIsNull(name, "Name is Null");
   }

   public string Name { get; set; }
}