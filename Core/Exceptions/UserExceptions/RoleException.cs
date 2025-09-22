namespace Core.Exceptions.UserExceptions;

public class RoleException: Exception
{
    private const string DefaultErrorMessage = "Row is Invalid";
    
    public RoleException(string message = DefaultErrorMessage):base(message){}
    
    public static void ThrowIsNull(string[]? item,string message = DefaultErrorMessage)
    {
        if (string.IsNullOrEmpty(item.ToString()))
            throw new Exception(message);
    }
}