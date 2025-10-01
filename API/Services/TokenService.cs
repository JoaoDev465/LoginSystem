using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Xml;
using Core.Entity;
using Core.Interfaces;
using Core.ValueObject.TokenEntityObject;
using Core.ValueObject.UserEntityObject;
using Microsoft.IdentityModel.Tokens;
using IdValue = Core.ValueObject.UserEntityObject.IdValue;

namespace _5442.Services;

public partial class TokenService : ITokenGenerator
{
    private readonly JwtSecurityTokenHandler _securityTokenHandler;

    public TokenService()
    {
        _securityTokenHandler = new JwtSecurityTokenHandler();
    }
    public Token GenerateToken(User user)
    {
        string refreshtoken = Guid.NewGuid().ToString("N");
        var createdat = DateTime.UtcNow;
        var expiredat = DateTime.UtcNow.AddHours(2);
        
        var secret = "banana1234oqewnoqenocdjeqncdowqjneoqewjnqoejncoqqecqe";
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var security = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: GenerateClaims(user),
            notBefore: createdat,
            expires: expiredat,
            signingCredentials:security
        );
        
        string acessToken =  _securityTokenHandler.WriteToken(token);
        
         return  new Token(
            id:null,
            userId: new IdValue(user.Id.Value)
            ,accessToken: new AcessToken(acessToken),
            tokenRefresh: new TokenRefresh(refreshtoken),
            lifetime: new TokenDateLifeTime(createdat,expiredat));
        
    }

    public ClaimsPrincipal? ValidateToken(Token token)
    {
        if (token.IsRevoked)
            return null;
        
        var secret = "banana1234oqewnoqenocdjeqncdowqjneoqewjnqoejncoqqecqe";
        var key = Encoding.UTF8.GetBytes(secret);

        try
        {
          var principal =  _securityTokenHandler.ValidateToken(token.AccessToken.Value, new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key)

            }, out _);

            return principal;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}