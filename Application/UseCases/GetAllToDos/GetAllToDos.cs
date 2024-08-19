using Application.Repositories;
using Core.Errors;
using Core.Monads;
using Core.Types;
using Core.UseCase;
using Domain.Entities.ToDo;

namespace Application.UseCases.GetAllToDos;

public class GetAllToDos : IUseCase<Unit, Either<ToDoError, List<ToDo>>>
{
    private readonly IToDoRepository _toDoRepository;

    public GetAllToDos(IToDoRepository toDoRepository)
    {
        _toDoRepository = toDoRepository;
    }

    public Either<ToDoError, List<ToDo>> Execute(Unit input)
    {
        return _toDoRepository.GetToDos();
    }
};