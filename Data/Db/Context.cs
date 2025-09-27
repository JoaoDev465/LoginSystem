using Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Db;

public class Context: DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    public DbSet<User> User { get; set; }
    public DbSet<Token> Token { get; set; }
}