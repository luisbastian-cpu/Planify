using MediatR;
using Microsoft.AspNetCore.Mvc;
using Planify.Application.Commands;
using Planify.Application.Queries;

[ApiController]
[Route("api/user-books")]
public class UserBooksController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserBooksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> Get(int userId)
    {
        var result = await _mediator.Send(new GetUserBooksQuery { UserId = userId });
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBook command)
    {
        var id = await _mediator.Send(command);
        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateUserBookCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteBook { Id = id });
        return Ok();
    }
}