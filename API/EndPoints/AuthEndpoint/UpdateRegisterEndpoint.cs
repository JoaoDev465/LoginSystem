using _5442.Common;
using Core.Contracts.AuthContract;
using Core.Entity;
using Core.Response;
using Core.UseCases;

namespace _5442.EndPoints.AuthEndpoint;

public class UpdateRegisterEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPut("/{id}", HandlerAsync)
            .WithName("Update: user register")
            .WithDescription("Updated Users and Tokens")
            .WithSummary("Updated Users and Tokens")
            .Produces < ResponseModel<Token?>>();
    }

    public static async Task<IResult> HandlerAsync(UpdateContract contract, UpdateUserHandler handler)
    {
       
        var response = await  handler.UpdateUserAsync(contract);
        if (response.Code != null && response.Code.IsSucess) TypedResults.Ok(response);
        if (response.Code != null && response.Code.IsError) TypedResults.NotFound(response);

        return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);

    }
}