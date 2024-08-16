namespace Domain.Entities.ToDo;

public record ToDoCreationData(string? Id, string Title, string Description, int Priority, string DueDate, int Status);