namespace Api.Communication;

public record CreateToDoResponse
{
    public required string Code { get; init; }
    public required string Message { get; init; }
    
    public static CreateToDoResponse Create(string code, string message) => new() { Code = code, Message = message };
};