namespace Core.Exceptions.TokenExceptions;

public class TokenLifeTimeException: Exception
{
    private const string DefaultErrorMessage = "Row Is invalid";

    public TokenLifeTimeException( string message = DefaultErrorMessage)
        : base(message){}
    

    public static void ThrowLifeTimeIsInvalid(DateTime? createdat, DateTime? expiredat,
        string message = DefaultErrorMessage)
    {
        if (createdat > expiredat)
            throw new TokenLifeTimeException(message);
    }
    
}