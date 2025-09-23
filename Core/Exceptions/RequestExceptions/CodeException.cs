namespace Core.Exceptions.RequestExceptions;

public class CodeException: Exception
{
    private const string DefaulErrorMessage = "Row is invalid";

    public CodeException(string message = DefaulErrorMessage) : base(message)
    {
    }

    public static void ThrowIfNull(int? item, string message = DefaulErrorMessage )
    {
        if (!item.HasValue)
            throw new CodeException(message);
    }
    
    public static void ThrowIfInvalidValue(int item, string message = DefaulErrorMessage )
    {
        if (item < 100 || item > 599)
            throw new CodeException(message);
    }
    
}