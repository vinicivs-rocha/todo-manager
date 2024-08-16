namespace Core.Errors;

public record DomainError
{
    public required string Message { get; init; }
    public required string Code { get; init; }
}