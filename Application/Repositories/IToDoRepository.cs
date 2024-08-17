using Core.Errors;
using Core.Monads;
using Core.Types;
using Domain.Entities.ToDo;

namespace Application.Repositories;

public interface IToDoRepository
{
    Either<ToDoError, Unit> CreateToDo(ToDo task);
    Either<ToDoError, ToDo> GetToDoById(string id);
    Either<ToDoError, List<ToDo>> GetToDos();
    Either<ToDoError, Unit> UpdateToDo(ToDo task);
    Either<ToDoError, Unit> DeleteToDo(string id);
}