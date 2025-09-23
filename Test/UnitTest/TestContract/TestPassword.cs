using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Core.Contracts.UserContract;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Test.UnitTest.TestContract;

public class TestPassword
{
    public static IList <ValidationResult> ValidationResults (object obj)
    {
        var context = new ValidationContext(obj, serviceProvider: null, items: null);
        var validation = new List<ValidationResult>();
        Validator.TryValidateObject(obj, context, validation, validateAllProperties: true);
        return validation;
    }
    [Fact]
    public void TestPasswordWhenIsnull()
    {

        var user = new UserContract { Password = null };

        var result = ValidationResults(user);

      Assert.Contains(result, r => r.ErrorMessage == "Password can't be null" );

    }

    [Fact]
    public void TestPasswordWhenNotRegexMatch()
    {
        var user = new UserContract { Password = "1234olae"  };

        var result = ValidationResults(user);

        Assert.Contains(result, r => r.ErrorMessage == "Password must contain 8 characters,1 especial character ex: !@#$%&," +
                       "1 long word,1 small word and 1 number" );

    }
    
    [Fact]
    public void TestPasswordWhenRegexMatchAndNotNull()
    {
        var user = new UserContract { Password = "1234$$Ga"  };
        var regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[!@#$&])(?=.*\d)[A-Za-z!@#$&\d]{8,}$");

        var result = regex.IsMatch(user.Password);
        
        Assert.True(result);

    }
}