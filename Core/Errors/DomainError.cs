namespace Core.Errors;

public sealed record DomainError(string Message, string Code)
{
    public static DomainError NotFound(string message) => new(message, "NotFound");
    public static DomainError InvalidDateTimeFormat(string message) => new DomainError(message, "InvalidDateTimeFormat");
    public static DomainError InvalidTaskPriority(string message) => new DomainError(message, "InvalidTaskPriority");
    public static DomainError InvalidTaskStatus(string message) => new DomainError(message, "InvalidTaskStatus");

}