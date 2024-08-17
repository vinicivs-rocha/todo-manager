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
    public IActionResult Create([FromBody] CreateToDoRequest createToDoRequest)
    {
        var result = _createToDo.Execute(new CreateToDoInput
        {
            Title = createToDoRequest.Title, Description = createToDoRequest.Description,
            Priority = createToDoRequest.Priority, DueDate = createToDoRequest.DueDate,
            Status = createToDoRequest.Status
        });
        
        if (result.IsLeft) return result.Left.Code switch
        {
            "InvalidToDoDateTimeFormat" => BadRequest(result.Left.Message),
            "InvalidToDoPriority" => BadRequest(result.Left.Message),
            "InvalidTodoDueDateFormat" => BadRequest(result.Left.Message),
            "ToDoNotFound" => NotFound(result.Left.Message),
            _ => BadRequest(result.Left.Message)
        };
        
        return Ok(result.Right);
    }
}