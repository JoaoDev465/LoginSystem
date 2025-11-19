namespace _5442.Common.ExtensiveApp;

public static class Documentation
{
    public static void DocApp(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}