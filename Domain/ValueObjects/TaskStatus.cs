using Core.Errors;
using Core.Monads;

namespace Domain.ValueObjects;

public struct TaskStatus
{
    public TaskStatusEnum Value { get; init; }

    public static Either<DomainError, TaskStatus> FromInt(int status)
    {
        if (!Enum.IsDefined(typeof(TaskStatusEnum), status))
        {
            return new DomainError
            {
                Code = "InvalidTaskStatus",
                Message = "Provided task status does not exists."
            };
        }

        return new TaskStatus { Value = (TaskStatusEnum)status };
    }
}