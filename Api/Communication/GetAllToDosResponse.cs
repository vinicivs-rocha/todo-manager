using System.Globalization;
using Domain.Entities.ToDo;

namespace Api.Communication;

public class GetAllToDosResponse(IEnumerable<GetAllToDosItem> toDos) : List<GetAllToDosItem>(toDos)
{
    public static GetAllToDosResponse Create(IEnumerable<ToDo> toDos) =>
        new(toDos.Select(GetAllToDosItem.Create));
};