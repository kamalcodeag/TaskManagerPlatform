using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagerPlatform.Application.Features.Tasks.Commands.CreateTask;
using TaskManagerPlatform.Application.Features.Tasks.Queries.GetTasks;
using TaskManagerPlatform.Application.Features.UserToTasks.Commands.CreateUserToTask;

namespace TaskManagerPlatform.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("gettasks")]
        public async Task<ActionResult<List<GetTasksQueryResponse>>> GetTasksAsync()
        {
            return Ok(await _mediator.Send(new GetTasksQuery()));
        }

        [HttpPost("createtask")]
        public async Task<ActionResult<CreateTaskCommandResponse>> CreateTaskAsync([FromBody] CreateTaskCommand createTaskCommand)
        {
            return Ok(await _mediator.Send(createTaskCommand));
        }

        [HttpPost("givetask")]
        public async Task<ActionResult<CreateUserToTaskCommandResponse>> GiveTaskAsync([FromBody] CreateUserToTaskCommand createUserToTaskCommand)
        {
            return Ok(await _mediator.Send(createUserToTaskCommand));
        }
    }
}