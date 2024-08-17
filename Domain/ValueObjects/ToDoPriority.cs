using Core.Monads;
using Core.Errors;

namespace Domain.ValueObjects;

public readonly struct ToDoPriority
{
    private ToDoPriorityEnum Value { get; init; }

    public static Either<ToDoError, ToDoPriority> FromInt(int priority)
    {
        if (!Enum.IsDefined(typeof(ToDoPriorityEnum), priority))
        {
            return ToDoError.InvalidToDoPriority("Provided task priority does not exist.");
        }

        return new ToDoPriority { Value = (ToDoPriorityEnum)priority };
    }
    
    public int ToInt() => (int)Value;
}