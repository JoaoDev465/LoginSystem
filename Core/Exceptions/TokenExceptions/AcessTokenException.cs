namespace Core.Exceptions.TokenExceptions;

public class AccessTokenException: Exception
{
    private const string DefaultErrorMessage = "Row Is invalid";
    
    public AccessTokenException(string message = DefaultErrorMessage): base(message){}

    public static void ThrowAcessTokenNull(string value, string message = DefaultErrorMessage)
    {
        if (string.IsNullOrEmpty(value))
            throw new AccessTokenException(message);
    }
}