namespace Core.Errors;

public sealed record ToDoError(string Message, string Code) : Error(Message, Code)
{
    public static ToDoError InvalidToDoDateTimeFormat(string message) => new(message, "InvalidToDoDateTimeFormat");
    public static ToDoError InvalidToDoPriority(string message) => new(message, "InvalidToDoPriority");
    public static ToDoError InvalidToDoStatus(string message) => new(message, "InvalidToDoStatus");
    public static ToDoError ToDoNotFound(string message) => new(message, "ToDoNotFound");
    public static ToDoError InvalidTodoDueDateFormat(string message) => new(message, "InvalidTodoDueDateFormat");
}