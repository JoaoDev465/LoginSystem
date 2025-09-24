using Core.Contracts.UserContract;
using Core.Entity;
using Core.Response;

namespace Core.UseCases;

public interface IUserHandler
{
    public Task<ResponseModel<User>> Login(UserContract contract);
}