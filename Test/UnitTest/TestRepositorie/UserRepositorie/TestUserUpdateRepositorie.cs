using Core.Entity;
using Core.ValueObject.UserEntityObject;
using Data.Db;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using IdValue = Core.ValueObject.TokenEntityObject.IdValue;

namespace Test.UnitTest.TestRepositorie;

public class TestUserUpdateRepositorie
{
    [Fact]
    public async Task TestUpdateWhenResultIsValid()
    {
        var options = new DbContextOptionsBuilder<Context>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString("N")).Options;

        var context = new Context(options);

        var user = new User(id: new Core.ValueObject.UserEntityObject.IdValue(1),
            name: new NameValue("joao"),
            email: new EmailValue("joao@gmail.com"),
            password: new PasswordValue("banana1234$$Ola"),
            roles: new RoleValue(new[] { "Adm" }));

        var repositorie = new UserRepositorie(context);


        await repositorie.Addasync(user);
        
        user.ChangeName(new NameValue("banana"));

     await    repositorie.UpdateUSer(user);

     var result = await context.User.FirstAsync(x => x.Id.Value == 1);
     Assert.Equal("banana",result.Name.Name );
    }
}