using Core.Entity;
using Core.Interfaces;
using Data.Db;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class TokenRepositorie: IAuthRepositorie
{
    private readonly Context _context;
    public TokenRepositorie(Context context)
    {
        _context = context;
    }
    public async Task AddAsync(Token token)
    {
        await _context.Token.AddAsync(token);
        await _context.SaveChangesAsync();
    }

    public async Task<Token?> GetByTokenRefresh(string tokenrefresh)
    {
        return await  _context.Token.AsNoTracking().FirstOrDefaultAsync(x => x.RefreshToken.Value == tokenrefresh);
    }

    public async  Task RefreshToken(Token token)
    {
       _context.Token.Update(token);
       await _context.SaveChangesAsync();
    }

    public async  Task RevokeByUserId(int id)
    {
        var token =  await _context.Token.FirstOrDefaultAsync(x =>x.UserId.Value == id);

        if (token != null) _context.Token.Remove(token);
    }
}