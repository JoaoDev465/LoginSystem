using Core.Exceptions.TokenExceptions;
using Core.ValueObject.TokenEntityObject;

namespace Test.UnitTest.TestValueObjects.TokenValues;

public class TestAccessToken
{
    [Fact]
    public void TestAcessTokenWhenTokenIsNull()
    {
        string? token = null;
        
        
       var result = Assert.Throws<AccessTokenException>(()=> new AcessToken(token));

       Assert.Contains("token can't be null", result.Message);
    }
}