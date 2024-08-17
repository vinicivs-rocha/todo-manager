using System.Globalization;
using Core.Errors;
using Core.ExtensionMethods;
using Core.Monads;
using Domain.ValueObjects;

namespace Domain.Entities.ToDo;

public class ToDo
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required ToDoPriority Priority { get; init; }
    public required DateTime DueDate { get; init; }
    public required ToDoStatus Status { get; init; }

    public static Either<ToDoError, ToDo> Create(ToDoCreationData toDoCreationData)
    {
        return from priority in ToDoPriority.FromInt(toDoCreationData.Priority)
            from status in ToDoStatus.FromInt(toDoCreationData.Status)
            from dueDate in toDoCreationData.DueDate.SafeParseToDateTime()
                .Cast(dateError => ToDoError.InvalidToDoDateTimeFormat(dateError.Message))
            select new ToDo
            {
                Title = toDoCreationData.Title,
                Description = toDoCreationData.Description,
                Priority = priority,
                DueDate = dueDate,
                Status = status
            };
    }
}