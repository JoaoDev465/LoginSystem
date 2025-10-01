namespace Core.Exceptions.TokenExceptions;

public class TokenRefreshException: Exception
{
    private const string DefaultErrorMessage = "Token Refresh is Invalid";
    
    public TokenRefreshException(string message = DefaultErrorMessage) :base(message){}

    public static  void ThrowRefreshNull(string value, string message = DefaultErrorMessage)
    {
        if (string.IsNullOrEmpty(value))
             throw new TokenRefreshException(message);
    }
    public static void ThrowRefresIsInvalid(string value,string expedValue, string message = DefaultErrorMessage)
    {
        if (!String.Equals(value, expedValue, StringComparison.Ordinal)) ;
    }
    
}