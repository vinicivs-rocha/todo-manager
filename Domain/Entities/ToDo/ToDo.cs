using Core.Errors;
using Core.Monads;
using Domain.ValueObjects;
using TaskStatus = Domain.ValueObjects.TaskStatus;

namespace Domain.Entities.ToDo;

public class ToDo
{
    public Guid Id { get; private init; } = Guid.NewGuid();
    public required string Title { get;  init; }
    public required string Description { get; init; }
    public required TaskPriority Priority { get; init; }
    public required DateTime DueDate { get; init; }
    public required TaskStatus Status { get; init; }

    public static Either<DomainError, ToDo> Create(ToDoCreationData data)
    {
        var priority = TaskPriority.FromInt(data.Priority);
        if (priority.IsLeft)
            return priority.Left;
        
        var status = TaskStatus.FromInt(data.Status);
        if (status.IsLeft)
            return status.Left;

        return new ToDo
        {
            Id = data.Id is not null ? Guid.Parse(data.Id) : Guid.NewGuid(),
            Title = data.Title,
            Description = data.Description,
            Priority = priority.Right,
            DueDate = DateTime.Parse(data.DueDate),
            Status = status.Right
        };
    }
}