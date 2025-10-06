using _5442.Common;
using Core.Contracts.AuthContract;
using Core.Entity;
using Core.Response;
using Core.UseCases;

namespace _5442.EndPoints.AuthEndpoint;

public class LoginEndPoint: IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("/", HAndlerAsync)
            .WithName("login")
            .WithSummary("login to user ")
            .WithDescription("login to user")
            .Produces<ResponseModel<Token?>>();
    }

    public static async Task<IResult> HAndlerAsync(LoginContract contract, AuthHandler handler)
    {
        var response = await handler.Login(contract);
        if (response.Code != null && response.Code.IsSucess) return TypedResults.Ok(response);
        if (response.Code != null && response.Code.IsError) return TypedResults.NotFound(response);

        return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
    }
}