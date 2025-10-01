using Core.Entity;
using Core.ValueObject.TokenEntityObject;
using Core.ValueObject.UserEntityObject;
using Data.Db;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Test.UnitTest.TestRepositorie.TokenRepositorie;

public class TestTokenUpdate
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
        
        var token = new Token(id: 1,
            userId: new Core.ValueObject.UserEntityObject.IdValue(user.Id.Value),
            accessToken: new AcessToken("qqoenjdoqdlqnjd1w334jwneaskn-qndlqnjd2jeqqld"),
            tokenRefresh: new TokenRefresh(Guid.NewGuid().ToString("N")),
            new TokenDateLifeTime(
                createdat: DateTime.UtcNow, expiredat: DateTime.UtcNow.AddHours(2))
        );

        var userrepositorie = new UserRepositorie(context);
        var tokenrepo = new Data.Repositories.TokenRepositorie(context);


        await userrepositorie.Addasync(user);
        await tokenrepo.AddAsync(token);
        
        token.ChangeTokenRefresh(new TokenRefresh("celwqeekjkjelnfclqnjeqne-jqnelcjqenljqjenfljqenflqjenf"));
        await tokenrepo.RefreshToken(token);

        var result = await context.Token.FirstAsync(x => x.Id.Value == token.Id);
        Assert.Equal("celwqeekjkjelnfclqnjeqne-jqnelcjqenljqjenfljqenflqjenf",result.RefreshToken.Value );
    }
}