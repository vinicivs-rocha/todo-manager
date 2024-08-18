namespace Application.UseCases.GetToDoById;

public record GetToDoByIdInput
{
    public required string Id { get; init; }
}