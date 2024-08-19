namespace Api.Communication;

public record UpdateToDoRequest(string? Title, string? Description, int? Priority, string? DueDate, int? Status);