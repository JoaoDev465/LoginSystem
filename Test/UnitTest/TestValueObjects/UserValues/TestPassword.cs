using Core.Exceptions.UserExceptions;
using Core.ValueObject;
using Core.ValueObject.EntityObject;

namespace Test.UnitTest.TestValueObjects;

public class TestPassword
{
    [Fact]
    public void TestPasswordWhenIsNull()
    {
        string? password = null;

        var result = Assert.Throws<PasswordException>(() => new PasswordValue(password));
        
        Assert.Contains("Password is null",result.Message);
    }

    [Fact]
    public void TestPasswordWhenNotNull()
    {
        string password = "jwdno2u3hdi2onjdlsqkm23f21oiufdo21dnoqi23ire2oji";

        var result = new PasswordValue(password);

        Assert.NotNull(result);
    }
}