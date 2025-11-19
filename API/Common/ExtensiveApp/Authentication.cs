namespace _5442.Common.ExtensiveApp;

public static class Authentication
{
    public static void AuthApp(this WebApplication app)
    {
        app.UseAuthorization();
        app.UseAuthentication();
    }
}