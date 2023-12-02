
/*
using DreamTeam.Application.TodoLists.Queries.GetTodos;

namespace DreamTeam.Web.Endpoints;

public class TodoLists : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetUsersLists)
            .MapPost(CreateUser)
            .MapPut(UpdateUser, "{id}")
            .MapDelete(DeleteUser, "{id}");
    }

    public async Task<TodosVm> GetUsersLists(ISender sender)
    {
        return await sender.Send(new GetTodosQuery());
    }

    public async Task<int> CreateUser(ISender sender, CreateTodoListCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> UpdateUser(ISender sender, int id, UpdateTodoListCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteUser(ISender sender, int id)
    {
        await sender.Send(new DeleteTodoListCommand(id));
        return Results.NoContent();
    }
}
*/
