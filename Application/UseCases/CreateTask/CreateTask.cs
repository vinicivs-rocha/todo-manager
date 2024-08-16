using Core.Errors;
using Core.Monads;
using Core.UseCase;
using Domain.Entities.ToDo;

namespace Application.UseCases.CreateTask;

public class CreateTask : IUseCase<CreateTaskInput, Either<DomainError, string>>
{
    public Either<DomainError, string> Execute(CreateTaskInput input)
    {
        return ToDo.Create(new ToDoCreationData
        {
            Title = input.Title,
            Description = input.Description,
            Priority = input.Priority,
            DueDate = input.DueDate,
            Status = input.Status
        }).Map(todo => todo.Id.ToString());
    }
}