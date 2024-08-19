using Application.Repositories;
using Core.Errors;
using Core.Monads;
using Core.Types;
using Core.UseCase;

namespace Application.UseCases.DeleteToDo;

public class DeleteToDo(IToDoRepository toDoRepository) : IUseCase<DeleteToDoInput, Either<ToDoError, Unit>>
{
    public Either<ToDoError, Unit> Execute(DeleteToDoInput input)
    {
        return from toDo in toDoRepository.GetToDoById(input.Id)
               from deletionResult in toDoRepository.DeleteToDo(toDo.Id.ToString())
               select deletionResult;
    }
}