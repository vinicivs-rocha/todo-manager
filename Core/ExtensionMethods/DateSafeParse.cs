using Core.Errors;
using Core.Monads;

namespace Core.ExtensionMethods;

public static class SafeParseStringToDateTime
{
    public static Either<DomainError, DateTime> SafeParseToDateTime(this string source)
    {
        try
        {
            return DateTime.Parse(source);
        }
        catch (FormatException e)
        {
           return DomainError.InvalidDateTimeFormat(e.Message);
        }
    }
}