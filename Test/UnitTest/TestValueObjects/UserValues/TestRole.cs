using Core.Exceptions.UserExceptions;
using Core.ValueObject;
using Core.ValueObject.UserEntityObject;

namespace Test.UnitTest.TestValueObjects;

public class TestRole
{
    [Fact]
    public void TestRoleWhenIsnull()
    {
        string[]? role = [];
        var result = Assert.Throws<RoleException>(() => new RoleValue(role));

        Assert.Contains("Role is null", result.Message);
    }

    [Fact]
    public void TestRoleWhenIsnotNull()
    {
        string[] role = ["admin", "user"];

        var result = new RoleValue(role);

        Assert.NotNull(result);
    }
}