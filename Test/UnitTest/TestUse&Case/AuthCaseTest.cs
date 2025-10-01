using _5442.Services;
using Core.Contracts.AuthContract;
using Core.Contracts.UserContract;
using Core.UseCases;
using Data.Db;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Test.UnitTest.TestUse_Case;

public class AuthCaseTest
{
    [Fact]
    public async Task TestWhenIsAGoodResult()
    {
        var options = new DbContextOptionsBuilder<Context>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString("N")).Options;
        var context = new Context(options);

        var userRepo = new UserRepositorie(context);
        var tokenRepo = new TokenRepositorie(context);
        var tokenservice = new TokenService();

        var logincontract = new LoginContract
        {
            Email = "joao@gmail.com",
            Password = "galo1234$$Ga"
        };

        var contract = new RegisterContract
        {
            Id = 1,
            Name = "joao",
            Email = "joao@gmail.com",
            Password = "galo1234$$Ga",
            Roles = new[] { "adm" }
        };

        var handler = new AuthHandler(userRepo, tokenservice, tokenRepo);

        var register = await handler.Register(contract);

        var login = await handler.Login(logincontract);
        
        
         Assert.Equal("Ok",login.Message);
        Assert.True(register.Code.IsSucess);
        Assert.Equal("Created",register.Message);
        Assert.Equal(201,register.Code.Value);


    }
}