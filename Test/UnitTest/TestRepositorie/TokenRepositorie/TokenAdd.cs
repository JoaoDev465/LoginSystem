using Core.Entity;
using Core.Exceptions.TokenExceptions;
using Core.Exceptions.UserExceptions;
using Core.ValueObject.TokenEntityObject;
using Core.ValueObject.UserEntityObject;
using Data.Db;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using IdValue = Core.ValueObject.UserEntityObject.IdValue;

namespace Test.UnitTest.TestRepositorie.TokenRepositorie;

public class TokenAdd
{
    

    [Fact]
    public async Task  TestWhenAddUserHasGoodResult()
    {
        var user = new User(
            id: new IdValue(1),
            name: new NameValue("joao"),
            email: new EmailValue("joao@gmail.com"),
            password: new PasswordValue("banana1234$$A"),
            roles: new RoleValue( new [] {"Adm"}));

        var token = new Token(id: 1,
            userId: new IdValue(user.Id.Value),
            accessToken: new AcessToken("qqoenjdoqdlqnjd1w334jwneaskn-qndlqnjd2jeqqld"),
            tokenRefresh: new TokenRefresh(Guid.NewGuid().ToString("N")),
            new TokenDateLifeTime(
                createdat: DateTime.UtcNow, expiredat: DateTime.UtcNow.AddHours(2))
        );
        

        var options = new DbContextOptionsBuilder<Context>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString("N")).Options;
        var context = new Context(options);
        var userRepo = new UserRepositorie(context);
        var tokenrepositorie = new Data.Repositories.TokenRepositorie(context);

        await userRepo.Addasync(user);
        await tokenrepositorie.AddAsync(token);
        

        var useradd = context.User.FirstOrDefaultAsync(x => x.Id == user.Id);
        var tokenadd = context.Token.FirstOrDefault(x => x.Id == token.Id);
     
        Assert.Equal(1,useradd.Id);
        Assert.Equal(1,tokenadd.Id);

    }
    
    [Fact]
    public void TestWhenUserPropertyIsInvalid()
    {

        var userid = 1;
        
        var result =  Assert.Throws<AccessTokenException>(()=> new Token(id: 1,
            userId: new IdValue(userid),
            accessToken: new AcessToken(null),
            tokenRefresh: new TokenRefresh(Guid.NewGuid().ToString("N")),
            new TokenDateLifeTime(
                createdat: DateTime.UtcNow, expiredat: DateTime.UtcNow.AddHours(2))
        ));
      
        Assert.Equal("token can't be null",result.Message);
    }
}