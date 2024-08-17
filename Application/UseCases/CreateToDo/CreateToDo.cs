using Application.Repositories;
using Core.Errors;
using Core.Monads;
using Core.UseCase;
using Domain.Entities.ToDo;

namespace Application.UseCases.CreateToDo;

public class CreateToDo : IUseCase<CreateToDoInput, Either<ToDoError, string>>
{
    private readonly IToDoRepository _toDoRepository;
    
    public CreateToDo(IToDoRepository toDoRepository)
    {
        _toDoRepository = toDoRepository;
    }
    
    public Either<ToDoError, string> Execute(CreateToDoInput input)
    {
        return from todo in ToDo.Create(new ToDoCreationData
            {
                Title = input.Title,
                Description = input.Description,
                Priority = input.Priority,
                DueDate = input.DueDate,
                Status = input.Status
            })
            let _ = _toDoRepository.CreateToDo(todo)
            select todo.Id.ToString();
    }
}