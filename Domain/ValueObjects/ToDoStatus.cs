using Core.Errors;
using Core.Monads;

namespace Domain.ValueObjects;

public struct ToDoStatus
{
    private ToDoStatusEnum Value { get; init; }

    public static Either<ToDoError, ToDoStatus> FromInt(int status)
    {
        if (!Enum.IsDefined(typeof(ToDoStatusEnum), status))
        {
            return ToDoError.InvalidToDoStatus("Provided task status does not exist.");
        }

        return new ToDoStatus { Value = (ToDoStatusEnum)status };
    }
    
    public int ToInt() => (int)Value;
}