using Core.Contracts.AuthContract;
using Core.Entity;
using Core.Interfaces;
using Core.Response;
using Core.ValueObject.UserEntityObject;

namespace Core.UseCases;

public class UpdateUserHandler
{
    private readonly IUserRepositorie _userRepositorie;
    private readonly IAuthRepositorie _authRepositorie;
    private readonly ITokenGenerator _tokenGenerator;

    public UpdateUserHandler(
        IAuthRepositorie authRepositorie,
        IUserRepositorie userRepositorie,
        ITokenGenerator tokenGenerator)
    {
        _userRepositorie = userRepositorie;
        _authRepositorie = authRepositorie;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<ResponseModel<Token?>> UpdateUserAsync
        (UpdateContract contract)
    {
        var user =await  _userRepositorie.GetUserById(contract.Id);
        
        if(user is null)
            return ResponseModel<Token?>.NotFound(null,"Not Found");
        
        user.ChangeEmail(new EmailValue(contract.Email));
        user.ChangePassword(new PasswordValue(contract.Password));

       await  _userRepositorie.UpdateUSer(user);

        if (user.Id != null) await _authRepositorie.RevokeByUserId(user.Id.Value);

      var token =  _tokenGenerator.GenerateToken(user);

      await _authRepositorie.AddAsync(token);


        return ResponseModel<Token?>.Success(token);
    }
}