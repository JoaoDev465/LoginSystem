using Core.Exceptions.UserExceptions;
using Core.ValueObject;
using Core.ValueObject.UserEntityObject;

namespace Test.UnitTest.TestValueObjects;

public class TestName
{
    [Fact]
    public void TestNameWhenIsnull()
    {
        string? name = null;
        var result = Assert.Throws<NameException>(() => new NameValue(name));

        Assert.Contains("Name is Null", result.Message);
    }
    
    [Fact]
    public void TestNameWhenIsNotNull()
    {
        string name = "joao";

        var result = new NameValue(name);

        Assert.NotNull(result);
    }
}