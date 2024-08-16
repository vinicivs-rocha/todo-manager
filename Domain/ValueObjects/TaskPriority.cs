using Core.Monads;
using Core.Errors;

namespace Domain.ValueObjects;

public readonly struct TaskPriority
{
    private TaskPriorityEnum Value { get; init; }

    public static Either<DomainError, TaskPriority> FromInt(int priority)
    {
        if (!Enum.IsDefined(typeof(TaskPriorityEnum), priority))
        {
            return DomainError.InvalidTaskPriority("Provided task priority does not exist.");
        }

        return new TaskPriority { Value = (TaskPriorityEnum)priority };
    }
    
    public int ToInt() => (int)Value;
}