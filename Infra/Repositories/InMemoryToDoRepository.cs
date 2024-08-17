using Application.Repositories;
using Core.Errors;
using Core.Monads;
using Core.Types;
using Domain.Entities.ToDo;

namespace Infra.Repositories;

public class InMemoryToDoRepository : IToDoRepository
{
    private readonly List<ToDo> _todos = [];


    public Either<ToDoError, Unit> CreateToDo(ToDo todo)
    {
            _todos.Add(todo);
            return Unit.Value;
    }

    public Either<ToDoError, ToDo> GetToDoById(string id)
    {
        try
        {
            return _todos.First(todo => todo.Id.ToString() == id);
        }
        catch (InvalidOperationException invalidOperationException)
        {
            return ToDoError.ToDoNotFound(invalidOperationException.Message);
        }
    }

    public Either<ToDoError, List<ToDo>> GetToDos()
    {
        return _todos;
    }

    public Either<ToDoError, Unit> UpdateToDo(ToDo todo)
    {
        try
        {
            var index = _todos.FindIndex(t => t.Id == todo.Id);
            _todos.Insert(index, todo);
            return Unit.Value;
        }
        catch (ArgumentOutOfRangeException argumentOutOfRangeException)
        {
            return ToDoError.ToDoNotFound(argumentOutOfRangeException.Message);
        }
    }

    public Either<ToDoError, Unit> DeleteToDo(string id)
    {
        _todos.RemoveAll(task => task.Id.ToString() == id);
        return Unit.Value;
    }
}