using Api.Communication;
using Application.UseCases.CreateToDo;
using Core.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ToDoController : ControllerBase
{
    private readonly CreateToDo _createToDo;

    public ToDoController(CreateToDo createToDo)
    {
        _createToDo = createToDo;
    }

    [HttpPost]
    [ProducesResponseType(type: typeof(CreteToDoResponse), statusCode: StatusCodes.Status201Created)]
    public IActionResult Create([FromBody] CreateToDoRequest createToDoRequest)
    {
        var result = _createToDo.Execute(new CreateToDoInput
        {
            Title = createToDoRequest.Title, Description = createToDoRequest.Description,
            Priority = createToDoRequest.Priority, DueDate = createToDoRequest.DueDate,
            Status = createToDoRequest.Status
        });

        if (result.IsLeft)
            return result.Left.Code switch
            {
                "InvalidToDoDateTimeFormat" => BadRequest(CreteToDoResponse.Create(code: result.Left.Code,
                    message: result.Left.Message)),
                "InvalidToDoPriority" => BadRequest(CreteToDoResponse.Create(code: result.Left.Code,
                    message: result.Left.Message)),
                "InvalidTodoDueDateFormat" => BadRequest(CreteToDoResponse.Create(code: result.Left.Code,
                    message: result.Left.Message)),
                "ToDoNotFound" => NotFound(CreteToDoResponse.Create(code: result.Left.Code,
                    message: result.Left.Message)),
                _ => BadRequest(CreteToDoResponse.Create(code: result.Left.Code, message: result.Left.Message))
            };

        return Created(Url.Action("GetById", "ToDo", new { id = result.Right }),
            CreteToDoResponse.Create(code: "SuccessfullyCreatedTodo", message: "ToDo created successfully"));
    }
}