namespace Core.Exceptions.UserExceptions;

public class NameException : Exception
{
    private const string DefaultErrorMessage = "Row is invalid";
    
    public NameException(string message = DefaultErrorMessage): base(message){}

    public static void ThrowIsNull(string? item,string message = DefaultErrorMessage)
    {
        if (string.IsNullOrEmpty(item))
            throw new Exception(message);
    }
}