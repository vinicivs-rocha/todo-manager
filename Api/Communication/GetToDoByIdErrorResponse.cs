namespace Api.Communication;

public record GetToDoByIdErrorResponse
{
    public required string Code { get; init; }
    public required string Message { get; init; }
    
    public static GetToDoByIdErrorResponse Create(string code, string message) => new() { Code = code, Message = message };
};