using Core.Monads;
using Core.Errors;

namespace Domain.ValueObjects;

public readonly struct TaskPriority
{
    public TaskPriorityEnum Value { get; private init; }

    public static Either<DomainError, TaskPriority> FromInt(int priority)
    {
        if (!Enum.IsDefined(typeof(TaskPriorityEnum), priority))
        {
            return new DomainError
            {
                Code = "InvalidTaskPriority",
                Message = "Provided task priority does not exists."
            };
        }

        return new TaskPriority { Value = (TaskPriorityEnum)priority };
    }
}