using Core.Entity;

namespace Core.Repositorie;

public interface IUserRepositorie
{
    public Task<User> Addasync(User user);
    public Task<User> GetUSerById(int Id);
    public Task<User> UpdateUSer(User user);
}