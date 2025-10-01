using System.ComponentModel.DataAnnotations;
using Core.Contracts.UserContract;

namespace Test.UnitTest.TestContract;

public class TestName
{
    public static IList <ValidationResult> ValidationResults (object obj)
    {
        var context = new ValidationContext(obj, serviceProvider: null, items: null);
        var validation = new List<ValidationResult>();
        Validator.TryValidateObject(obj, context, validation, validateAllProperties: true);
        return validation;
    }
    [Fact]
    public void TestNameWhenIsNull()
    {
        var user = new AuthContract
        {
            Email = "joao@gmail.com",
            Password = "1234$$Ga",
            Name = null
        };

        var result = ValidationResults(user);
        
        Assert.Contains(result, r => r.ErrorMessage == "name's row can't be null");
    }
}