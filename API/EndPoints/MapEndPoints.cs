using _5442.Common;
using _5442.EndPoints.AuthEndpoint;
using Microsoft.AspNetCore.Http.HttpResults;

namespace _5442.EndPoints;

public static class MapEndPoints
{
    public static void MapEndPoint(this WebApplication app)
    {

        app.MapGet("/", () => new { message = "Ok" })
            .WithTags("Health Check");

        app.MapGroup("auth/register")
            .WithTags("Register")
            .MapEndpoint<RegisterEndPoint>();

        app.MapGroup("auth/login")
            .WithTags("Login")
            .MapEndpoint<LoginEndPoint>();

        app.MapGroup("auth/update")
            .WithTags("Update")
            .MapEndpoint<UpdateRegisterEndpoint>();

    }
    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}