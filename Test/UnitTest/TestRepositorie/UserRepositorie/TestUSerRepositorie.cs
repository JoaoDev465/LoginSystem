using Core.Entity;
using Core.Exceptions.UserExceptions;
using Core.ValueObject.UserEntityObject;
using Data.Db;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Test.UnitTest.TestRepositorie;

public class TestUSerRepositorie
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
        

        var options = new DbContextOptionsBuilder<Context>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString("N")).Options;
        var context = new Context(options);

        var repositorie = new UserRepositorie(context);

        await repositorie.Addasync(user);

        var useradd = context.User.FirstOrDefaultAsync(x => x.Id == user.Id);
     
     Assert.Equal(1,useradd.Id);

    }
    
    [Fact]
    public void TestWhenUserPropertyIsInvalid()
    {
        
        
      var result =  Assert.Throws<EmailException>(()=> new User(
          id: new IdValue(1),
          name: new NameValue("joao"),
          email: new EmailValue("joaogmail.com"),
          password: new PasswordValue("banana1234$$Ola"),
          roles: new RoleValue(new [] {"Adm"})));
      
      Assert.Equal("Email not Equal '@gmail.com'",result.Message);
    }
}
