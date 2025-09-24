using Core.Contracts.UserContract;
using Core.Entity;
using Core.Response;

namespace Core.UseCases;

public interface IAuthHandler
{ 
   public Task<ResponseModel<User>> Login(UserContract contract);
   
   public Task<ResponseModel<User>> Register(UserContract contract);


}