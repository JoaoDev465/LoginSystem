using Microsoft.OpenApi.Models;

namespace _5442.Common.ExtensiveAppBuilder;

public static class Documentation
{
    public static void SwachbuckleSwagge(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(x =>
        {
            var securitySchema = new OpenApiSecurityScheme
            {
                Name = "Security",
                Description = "this is a Autentication Software that it's using JWT Credentials",
                BearerFormat = "Jwt",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            };
            
            x.AddSecurityDefinition("Bearer",securitySchema);

            var securityRequirement = new OpenApiSecurityRequirement
            {
                {
                    securitySchema,
                    new string[] { }
                }
            };
            x.AddSecurityRequirement(securityRequirement);
        });
    }
}