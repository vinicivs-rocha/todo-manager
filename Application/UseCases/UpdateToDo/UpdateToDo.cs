using Application.Repositories;
using Core.Errors;
using Core.Monads;
using Core.Types;
using Core.UseCase;
using Domain.Entities.ToDo;

namespace Application.UseCases.UpdateToDo;

public class UpdateToDo(IToDoRepository toDoRepository) : IUseCase<UpdateToDoInput, Either<ToDoError, Unit>>
{
    public Either<ToDoError, Unit> Execute(UpdateToDoInput input)
    {
        return from existingTodo in toDoRepository.GetToDoById(input.Id)
            from toDo in ToDo.Create(new ToDoCreationData
            {
                Id = input.Id,
                Title = input.Title ?? existingTodo.Title,
                Description = input.Description ?? existingTodo.Description,
                Priority = input.Priority ?? existingTodo.Priority.ToInt(),
                DueDate = input.DueDate ?? existingTodo.DueDate.ToString("yyyy-MM-dd"),
                Status = input.Status ?? existingTodo.Status.ToInt(),
            })
            from _ in toDoRepository.UpdateToDo(toDo)
            select Unit.Value;
    }
}