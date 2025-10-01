using Core.Contracts.AuthContract;
using Core.Contracts.UserContract;
using Core.Entity;
using Core.Interfaces;
using Core.Response;
using Core.ValueObject;
using Core.ValueObject.UserEntityObject;
using SecureIdentity.Password;

namespace Core.UseCases;

public class AuthHandler
{
    private readonly IUserRepositorie _userRepositorie;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly IAuthRepositorie _authRepositorie;

    public AuthHandler(IUserRepositorie userRepositorie,
        ITokenGenerator generator,
        IAuthRepositorie repositorie)
    {
        _userRepositorie = userRepositorie;
        _tokenGenerator = generator;
        _authRepositorie = repositorie;
    }
    
   public async Task<ResponseModel<Token>> Login(LoginContract contract)
   {
       var user = await _userRepositorie.GetUSerByEmail(contract.Email);
       if(user.Email is null)
           return ResponseModel<Token>.NotFound(null,"not users found");
       
       if (!PasswordHasher.Verify(user.Password.Password, contract.Password)) 
           return ResponseModel<Token>.BadRequest(null,"invalid password");

       var token = _tokenGenerator.GenerateToken(user);

       await _authRepositorie.AddAsync(token);

       return ResponseModel<Token>.Success(token);

   }

   public async Task<ResponseModel<User>> Register(RegisterContract contract)
   {
     var password =  PasswordHasher.Hash(contract.Password);
       
        var user= new User(new IdValue(contract.Id),
               new NameValue(contract.Name),
               new EmailValue(contract.Email),
               new PasswordValue(password),
               new RoleValue(contract.Roles));
     
        await _userRepositorie.Addasync(user);
        _tokenGenerator.GenerateToken(user);

        return  ResponseModel<User>.Created(user);
   }


}