using System.Globalization;
using Domain.Entities.ToDo;

namespace Api.Communication;

public record GetAllToDosItem
{
    public required string Id { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required int Priority { get; init; }
    public required string DueDate { get; init; }
    public required int Status { get; init; }

    public static GetAllToDosItem Create(ToDo toDo) => new()
    {
        Id = toDo.Id.ToString(), Title = toDo.Title, Description = toDo.Description,
        Priority = toDo.Priority.ToInt(), DueDate = toDo.DueDate.ToString(CultureInfo.InvariantCulture),
        Status = toDo.Status.ToInt()
    };
};