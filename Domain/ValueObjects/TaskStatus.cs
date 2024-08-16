using Core.Errors;
using Core.Monads;

namespace Domain.ValueObjects;

public struct TaskStatus
{
    private TaskStatusEnum Value { get; init; }

    public static Either<DomainError, TaskStatus> FromInt(int status)
    {
        if (!Enum.IsDefined(typeof(TaskStatusEnum), status))
        {
            return DomainError.InvalidTaskStatus("Provided task status does not exist.");
        }

        return new TaskStatus { Value = (TaskStatusEnum)status };
    }
    
    public int ToInt() => (int)Value;
}