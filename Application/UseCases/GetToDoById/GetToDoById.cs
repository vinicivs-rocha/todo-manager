using Application.Repositories;
using Core.Errors;
using Core.Monads;
using Core.UseCase;
using Domain.Entities.ToDo;

namespace Application.UseCases.GetToDoById;

public class GetToDoById : IUseCase<GetToDoByIdInput, Either<ToDoError, ToDo>>
{
    private readonly IToDoRepository _toDoRepository;

    public GetToDoById(IToDoRepository toDoRepository)
    {
        _toDoRepository = toDoRepository;
    }

    public Either<ToDoError, ToDo> Execute(GetToDoByIdInput input)
    {
        return from todo in _toDoRepository.GetToDoById(input.Id)
            select todo;
    }
}