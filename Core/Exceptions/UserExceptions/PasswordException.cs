using System.Text.RegularExpressions;

namespace Core.Exceptions.UserExceptions;

public class PasswordException : Exception
{
    private const string DefaultErrorMessage = "Row is invalid";
    
    public PasswordException(string message = DefaultErrorMessage):base(message){}
    
    public static void ThrowIsNull(string? item,string message = DefaultErrorMessage)
    {
        if (string.IsNullOrEmpty(item))
            throw new Exception(message);
    }

    public static void ThrowIsNotMath(string? item,string message = DefaultErrorMessage)
    {
        var regex = new Regex(@"(?=.*[A-Z])(?=.*[a-z])(?=.*[@#$%&!])(?=.*[\d])([A-Za-z@#$&!\d]){8,}$");
        if (!regex.IsMatch(item))
            throw new Exception(message);
    }
}