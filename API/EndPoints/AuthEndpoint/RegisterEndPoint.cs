using _5442.Common;
using Core.Contracts.AuthContract;
using Core.Entity;
using Core.Response;
using Core.UseCases;

namespace _5442.EndPoints.AuthEndpoint;

public class RegisterEndPoint: IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("/",HAndlerAsync)
            .WithName("Auth: Register")
            .WithOrder(1)
            .WithSummary("register an new user")
            .Produces<ResponseModel<User?>>();

    }

    public static async Task <IResult>HAndlerAsync(RegisterContract contract, AuthHandler handler)
    {
        var response = await  handler.Register(contract);
        if (response.Code != null && response.Code.IsSucess) return TypedResults.Created($"/auth/register/{contract.Id}", response);
        if (response.Code != null && response.Code.IsError) return TypedResults.BadRequest(response);

        return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
    }
}