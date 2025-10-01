namespace Core.Exceptions.TokenExceptions;

public class AccessTokenException: Exception
{
    private const string DefaultErrorMessage = "Access token is Invalid";
    
    public AccessTokenException(string message = DefaultErrorMessage): base(message){}

    public static void ThrowAccessTokenIsNull(string value, string message = DefaultErrorMessage)
    {
        if (string.IsNullOrEmpty(value))
            throw new AccessTokenException(message);
    }
    
}