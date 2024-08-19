using System.Globalization;
using Api.Communication;
using Application.UseCases.CreateToDo;
using Application.UseCases.GetAllToDos;
using Application.UseCases.GetToDoById;
using Core.Types;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ToDoController(CreateToDo createToDo, GetToDoById getToDoById, GetAllToDos getAllToDos) : ControllerBase
{

    [HttpPost]
    [ProducesResponseType(type: typeof(CreateToDoResponse), statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(type: typeof(CreateToDoResponse), statusCode: StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] CreateToDoRequest createToDoRequest)
    {
        var result = createToDo.Execute(new CreateToDoInput
        {
            Title = createToDoRequest.Title, Description = createToDoRequest.Description,
            Priority = createToDoRequest.Priority, DueDate = createToDoRequest.DueDate,
            Status = createToDoRequest.Status
        });

        if (result.IsLeft)
            return result.Left.Code switch
            {
                "InvalidToDoDateTimeFormat" => BadRequest(CreateToDoResponse.Create(code: result.Left.Code,
                    message: result.Left.Message)),
                "InvalidToDoPriority" => BadRequest(CreateToDoResponse.Create(code: result.Left.Code,
                    message: result.Left.Message)),
                "InvalidTodoDueDateFormat" => BadRequest(CreateToDoResponse.Create(code: result.Left.Code,
                    message: result.Left.Message)),
                "ToDoNotFound" => NotFound(CreateToDoResponse.Create(code: result.Left.Code,
                    message: result.Left.Message)),
                _ => BadRequest(CreateToDoResponse.Create(code: result.Left.Code, message: result.Left.Message))
            };

        return Created(Url.Action("GetById", "ToDo", new { id = result.Right }),
            CreateToDoResponse.Create(code: "SuccessfullyCreatedTodo", message: "ToDo created successfully"));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(type: typeof(GetToDoByIdSuccessResponse), statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(type: typeof(GetToDoByIdErrorResponse), statusCode: StatusCodes.Status404NotFound)]
    [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
    public IActionResult GetById([FromRoute] string id)
    {
        var result = getToDoById.Execute(new GetToDoByIdInput { Id = id });

        if (result.IsLeft)
            return result.Left.Code switch
            {
                "ToDoNotFound" => NotFound(GetToDoByIdErrorResponse.Create(code: result.Left.Code,
                    message: result.Left.Message)),
                _ => Problem(detail: result.Left.Message, statusCode: StatusCodes.Status500InternalServerError)
            };

        return Ok(new GetToDoByIdSuccessResponse
        {
            Id = result.Right.Id.ToString(), Title = result.Right.Title, Description = result.Right.Description,
            Priority = result.Right.Priority.ToInt(),
            DueDate = result.Right.DueDate.ToString(CultureInfo.InvariantCulture), Status = result.Right.Status.ToInt()
        });
    }

    [HttpGet]
    [ProducesResponseType(type: typeof(GetAllToDosResponse), statusCode: StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        var result = getAllToDos.Execute(Unit.Value);

        if (result.IsLeft)
            return Problem(detail: result.Left.Message, statusCode: StatusCodes.Status500InternalServerError);

        return Ok(GetAllToDosResponse.Create(result.Right));
    }
}