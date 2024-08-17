namespace Core.Errors;

public sealed record DateError(string Message, string Code) : Error(Message, Code)
{
    public static DateError InvalidDateTimeFormat(string message) => new(message, "InvalidDateTimeFormat");
}