using Core.Entity;

namespace Core.Interfaces;

public interface IUserRepositorie
{
    public Task Addasync(User user);
    public Task<User?> GetUSerByEmail(string email);
    public Task  UpdateUSer(User user);
}