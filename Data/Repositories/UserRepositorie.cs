using Core.Entity;
using Core.Interfaces;
using Data.Db;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class UserRepositorie: IUserRepositorie
{
    private readonly Context _context;

    public UserRepositorie(Context context)
    {
        _context = context;
    }
    public async Task Addasync(User user)
    {
      await  _context.User.AddAsync(user);
      await _context.SaveChangesAsync();
    }

    public async  Task<User?> GetUSerByEmail(string email)
    {
        return await  _context.User.AsNoTracking().FirstOrDefaultAsync(x=>x.Email.Email == email);
    }

    public  async Task  UpdateUSer(User user)
    {
        _context.User.Update(user);
        await _context.SaveChangesAsync();
    }
}