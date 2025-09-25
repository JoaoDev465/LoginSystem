namespace Core.Exceptions.TokenExceptions;

public class TokenRefreshException: Exception
{
    private const string DefaultErrorMessage = "Row is invalid";
    
    public TokenRefreshException(string message = DefaultErrorMessage) :base(message){}

    public static  void ThrowRefreshNull(string value, string message = DefaultErrorMessage)
    {
        if (string.IsNullOrEmpty(value))
             throw new TokenRefreshException(message);
    }
}