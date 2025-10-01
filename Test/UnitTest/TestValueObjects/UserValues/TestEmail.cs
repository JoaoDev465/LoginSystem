using Core.Exceptions.UserExceptions;
using Core.ValueObject;
using Core.ValueObject.UserEntityObject;

namespace Test.UnitTest.TestValueObjects;

public class TestEmail
{
    [Fact]
    public void TestEmailWhenIsNull()
    {
        string? email = null;

     var result = Assert.Throws<EmailException>(() => new EmailValue(email));
     
     Assert.Contains("Email is null", result.Message);

    }

    [Fact]
    public void TestEmailWhenIsNotNull()
    {
        var Email = "joao@gmail.com";
        var result = new EmailValue(Email);

        Assert.NotNull(result);
    }

    [Fact]
    public void TestEmailWhenNotContaingmail()
    {
        var email = "joao";

        var result = Assert.Throws<EmailException>(() => new EmailValue(email));

        Assert.Contains("Email not Equal '@gmail.com'", result.Message);
    }
}