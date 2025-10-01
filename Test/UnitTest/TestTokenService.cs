using System.Security.Claims;
using _5442.Services;
using Core.Entity;
using Core.ValueObject.TokenEntityObject;
using Core.ValueObject.UserEntityObject;
using IdValue = Core.ValueObject.TokenEntityObject.IdValue;

namespace Test.UnitTest;

public class TestTokenService
{
    [Fact]
    public void TestWhenResultIsOkay()
    {
        var token = new TokenService();
        
        var user = new User(id: new Core.ValueObject.UserEntityObject.IdValue(1),
            name: new NameValue("joao"),
            email: new EmailValue("joao@gmail.com"),
            password: new PasswordValue("banana1234$$A"),
            roles: new RoleValue(new[] { "Adm" }));
        
        var result = token.GenerateToken(user: user);
        var principal = token.ValidateToken(result);
        
        var emailClaim = principal.Claims.
            FirstOrDefault(x => x.Type == ClaimTypes.Email);
        var namelClaim = principal.Claims.FirstOrDefault
            (x => x.Type == ClaimTypes.Name);
        var roleClaim = principal.Claims.FirstOrDefault
            (x => x.Type == ClaimTypes.Role);

        Assert.NotNull(result);
        Assert.True(result.IsValid());
        Assert.NotNull(principal);
        Assert.NotNull(emailClaim);
        Assert.Equal(user.Email.Email,emailClaim.Value);
        Assert.Equal(user.Name.Name,namelClaim.Value);
        Assert.Equal("Adm",roleClaim.Value);
        // Assert.Equal(user.Name.Name, validate.Value);


    }
}