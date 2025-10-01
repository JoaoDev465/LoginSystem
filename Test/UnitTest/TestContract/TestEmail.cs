using System.ComponentModel.DataAnnotations;
using Core.Contracts.UserContract;

namespace Test.UnitTest.TestContract;

public class TestEmail
{
    public static IList <ValidationResult> ValidationResults (object obj)
    {
        var context = new ValidationContext(obj, serviceProvider: null, items: null);
        var validation = new List<ValidationResult>();
        Validator.TryValidateObject(obj, context, validation, validateAllProperties: true);
        return validation;
    }
    [Fact]
    public void TesEmailWhenIsnull()
    {
        var user = new AuthContract { Email = null };

        var result = ValidationResults(user);

        Assert.Contains(result, r => r.ErrorMessage == "The Field Email can't be null");
    }
    [Fact]
    public void TesEmailWhenNotHaveGmail()
    {
        var user = new AuthContract { Email = "joao"};

        var result = ValidationResults(user);

        Assert.Contains(result, r => r.ErrorMessage == "Email's row must have a '@gmail.com'");
    }

    [Fact]
    public void TestEmailWhenIsvalid()
    {
        var user = new AuthContract
        {
            Email = "joao@gmail.com",
            Name = "joao",
            Password = "1234$$Ga"
        };
    
        var result = ValidationResults(user);
    
        Assert.Empty(result);
    }
    
    
}