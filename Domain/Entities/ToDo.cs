using Domain.ValueObjects;
using TaskStatus = Domain.ValueObjects.TaskStatus;

namespace Domain.Entities;

public class ToDo
{
    public string Id { get; init; } = Guid.NewGuid().ToString();
    public required string Title { get; init; }
    public required string Description { get; init; }
    public TaskPriority Priority { get; init; }
    public required DateTime DueDate { get; init; }
    public required TaskStatus Status { get; init; }
}