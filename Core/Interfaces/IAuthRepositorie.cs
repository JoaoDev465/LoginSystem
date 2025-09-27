using Core.Contracts.UserContract;
using Core.Entity;

namespace Core.Interfaces;

public interface IAuthRepositorie 
{
    public Task AddAsync(Token token);
    public Task<Token?> GetByTokenRefresh(string tokenrefresh);
    public Task RefreshToken(Token token);
}