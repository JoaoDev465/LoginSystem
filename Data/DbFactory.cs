using Data.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace Data;

public class DbFactory : IDesignTimeDbContextFactory<Context>
{
    
    public Context CreateDbContext(string[] args)
    {
        var json = new ConfigurationBuilder().add
        var options = new DbContextOptionsBuilder<Context>();

        options.UseSqlServer(connection);
        return new Context(options.Options);
    }
}