using System.Security.Claims;
using Core.Entity;

namespace _5442.Services;

public partial class TokenService
{
    private static IEnumerable<Claim> GenerateClaims(User user)
    {
        var ci = new ClaimsIdentity();
        
        ci.AddClaim(new Claim("Id", user.Id.Value.ToString()));
        ci.AddClaim(new Claim(ClaimTypes.Name, user.Name.Name));
        ci .AddClaim(new Claim(ClaimTypes.Email, user.Email.Email));

        foreach (var role in user.Roles.Role)
            ci.AddClaim(new Claim(ClaimTypes.Role,role));

        return ci.Claims;
    }
}