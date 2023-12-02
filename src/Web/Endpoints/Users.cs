using DreamTeam.Application.Users.Commands.CreateUser;
using DreamTeam.Application.Users.Queries.GetUser;
using DreamTeam.Infrastructure.Identity;

namespace DreamTeam.Web.Endpoints;

public class Users : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        /*app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetTodoLists)
            .MapPost(CreateTodoList)
            .MapPut(UpdateTodoList, "{id}")
            .MapDelete(DeleteTodoList, "{id}");*/

        app.MapGroup(this)
            //.MapIdentityApi<ApplicationUser>()
            .MapPost(CreateUser)
            .MapGet(GetUser);
    }
    
    private async Task<IResult> GetUser(ISender sender, GetUserQuery query)
    {
        return Results.Ok(await sender.Send(query));
    }
    
    private async Task<IResult> CreateUser(ISender sender, CreateUserCommand command)
    {
        return Results.Ok(await sender.Send(command));
    }
}
