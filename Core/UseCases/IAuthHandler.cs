using Core.Contracts.UserContract;
using Core.Entity;
using Core.Repositorie;
using Core.Response;
using Core.ValueObject;
using Core.ValueObject.EntityObject;
using Core.ValueObject.UserEntityObject;

namespace Core.UseCases;

public class AuthHandler
{
    private readonly IUserRepositorie _userRepositorie;

    public AuthHandler(IUserRepositorie userRepositorie)
    {
        _userRepositorie = userRepositorie;
    }
    
   public async Task<ResponseModel<User>> Login(UserContract contract)
   {
       return null;
   }

   public async Task<ResponseModel<User>> Register(UserContract contract)
   {
     var user= new User(new IdValue(contract.Id),
               new NameValue(contract.Name),
               new EmailValue(contract.Email),
               new PasswordValue(contract.Password),
               new RoleValue(contract.Roles));
     
     await _userRepositorie.Addasync(user);

     return  ResponseModel<User>.Created(user);
   }


}