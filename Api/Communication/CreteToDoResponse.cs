namespace Api.Communication;

public record CreteToDoResponse
{
    public required string Code { get; init; }
    public required string Message { get; init; }
    
    public static CreteToDoResponse Create(string code, string message) => new CreteToDoResponse { Code = code, Message = message };
};