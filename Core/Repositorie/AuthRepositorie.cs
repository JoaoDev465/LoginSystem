using Core.Entity;
using Core.UseCases;

namespace Core.Repositorie;

public interface IAuthRepositorie
{
    public Task<Token> AddAsync(Token token);
    public Task<Token> GetByTokenRefresh(string tokenrefresh);
    public Task<Token> RefreshToken(Token token);
}