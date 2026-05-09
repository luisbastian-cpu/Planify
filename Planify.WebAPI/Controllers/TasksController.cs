using MediatR;
using Microsoft.AspNetCore.Mvc;
using Planify.Application.Commands;
using Planify.Application.Queries;

namespace Planify.WebAPI.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet ("Obtener_tareas")]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetTasksQuery());
            return Ok(result);
        }

        [HttpPost("Crear_tareas")]
        public async Task<IActionResult> Create([FromBody] CreateTaskCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("Actualizar_tarea/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTaskCommand command)
        {
            
            if (id != command.Id)
            {
                return BadRequest("El ID proporcionado no coincide con el de la tarea.");
            }

            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("Eliminar_tarea/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteTaskCommand(id));
            return Ok();
        }
    }
}