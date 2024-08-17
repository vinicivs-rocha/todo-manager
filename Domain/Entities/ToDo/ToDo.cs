using System.Globalization;
using Core.Errors;
using Core.ExtensionMethods;
using Core.Monads;
using Domain.ValueObjects;
using TaskStatus = Domain.ValueObjects.TaskStatus;

namespace Domain.Entities.ToDo;

public class ToDo
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required TaskPriority Priority { get; init; }
    public required DateTime DueDate { get; init; }
    public required TaskStatus Status { get; init; }

    public static Either<DomainError, ToDo> Create(ToDoCreationData toDoCreationData)
    {
        return from priority in TaskPriority.FromInt(toDoCreationData.Priority)
            from status in TaskStatus.FromInt(toDoCreationData.Status)
            from dueDate in toDoCreationData.DueDate.SafeParseToDateTime()
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