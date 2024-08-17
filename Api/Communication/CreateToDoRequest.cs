namespace Api.Communication;

public record CreateToDoRequest
{
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required string DueDate { get; init; }
    public required int Priority { get; init; }
    public required int Status { get; init; }
};