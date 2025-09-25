using System.Text.Json.Serialization;
using Core.Exceptions.RequestExceptions;

namespace Core.ValueObject.ResponseObject;

public record Code 
{
   public Code(int value)
   {
      Value = value;
      CodeException.ThrowIfInvalidValue(value, "invalid HTTP status  code");
   }
   public int Value { get; }
   public bool IsSucess => Value is >= 200 and <= 299;
   public bool IsError => Value is >= 400 and <= 499;

   [JsonIgnore] public static Code? Ok => new(200);
   [JsonIgnore]public static Code Created => new(201);
   [JsonIgnore]public static Code? BadRequest => new(400);
   [JsonIgnore]public static Code NotFound => new(404);
   [JsonIgnore]public static Code InternalError => new(500);

   public override string ToString()
   {
      return Value.ToString();
   }
}