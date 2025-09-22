namespace Core.Exceptions.UserExceptions;

public class EmailException : Exception
{
    private const string DefaulErrorMessage = "Row is invalid";

    public EmailException(string message = DefaulErrorMessage) : base(message)
    {
    }

    public static void ThrowIfNull(string? item, string message = DefaulErrorMessage )
    {
        if (string.IsNullOrEmpty(item))
            throw new Exception(message);
    }

    public static void ThrowIfNotContains(string? item, string message = DefaulErrorMessage)
    {
        if (!string.Equals(item, "@gmail.com"))
            throw new Exception(message);
    }
}