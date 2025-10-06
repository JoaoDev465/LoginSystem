using _5442.Services;
using Core.Interfaces;
using Core.UseCases;
using Data.Db;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace _5442.Common.ExtensiveAppBuilder;

public static class ServiceBuilder
{
    public static void Services(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<AuthHandler>();
        builder.Services.AddTransient<UpdateUserHandler>();
        builder.Services.AddDbContext<Context>(options =>
        {
            options.UseInMemoryDatabase(Guid.NewGuid().ToString());
        });

        builder.Services.AddScoped<IUserRepositorie,UserRepositorie>();
        builder.Services.AddScoped<ITokenGenerator, TokenService>();
        builder.Services.AddScoped<IAuthRepositorie,TokenRepositorie>();
    }
}