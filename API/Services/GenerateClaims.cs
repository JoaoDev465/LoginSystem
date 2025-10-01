using System.Security.Claims;
using Core.Entity;

namespace _5442.Services;

public static class GenerateClaims
{
    public static int Id(this ClaimsPrincipal user)
    {
        try
        {
            var id = user.Claims.
                FirstOrDefault(x => x.Type == "Id")
                ?.Value ?? "0";
            return int.Parse(id);
        }
        catch (Exception e)
        {
            return 0;
        }
    }
    
    public static string Name (this ClaimsPrincipal user)
    {
        try
        {
            var name = user.Claims.
                FirstOrDefault(x => x.Type == ClaimTypes.Name)
                ?.Value ?? String.Empty;
            return string.Empty;
        }
        catch (Exception e)
        {
           return String.Empty;
        }
    }
    public static string Email (this ClaimsPrincipal user)
    {
        try
        {
            var email = user.Claims.
                FirstOrDefault(x => x.Type == ClaimTypes.Email)
                ?.Value ?? String.Empty;
            return string.Empty;
        }
        catch (Exception e)
        {
            return String.Empty;
        }
    }
}