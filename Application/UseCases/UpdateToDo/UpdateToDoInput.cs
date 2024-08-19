namespace Application.UseCases.UpdateToDo;

public record UpdateToDoInput(string Id, string? Title, string? Description, int? Priority, string? DueDate, int? Status);