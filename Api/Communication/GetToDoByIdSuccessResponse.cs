namespace Api.Communication;

public record GetToDoByIdSuccessResponse
{
    public required string Id { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required int Priority { get; init; }
    public required string DueDate { get; init; }
    public required int Status { get; init; }

    public static GetToDoByIdSuccessResponse Create(string id, string title, string description, int priority,
        string dueDate, int status) => new()
        { Id = id, Title = title, Description = description, Priority = priority, DueDate = dueDate, Status = status };
};