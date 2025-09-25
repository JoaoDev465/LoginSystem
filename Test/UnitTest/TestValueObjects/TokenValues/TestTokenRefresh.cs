using Core.Exceptions.TokenExceptions;
using Core.ValueObject.TokenEntityObject;

namespace Test.UnitTest.TestValueObjects.TokenValues;

public class TestTokenRefresh
{
    [Fact]
    public void TestTokenRefreshWhenTokenIsNull()
    {
        string? token = null;
        
        
        var result = Assert.Throws<TokenRefreshException>(()=> new TokenRefresh(token));

        Assert.Contains("Token can't be null", result.Message);
    }
}