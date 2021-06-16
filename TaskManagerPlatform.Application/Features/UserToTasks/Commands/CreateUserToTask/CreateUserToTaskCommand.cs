using MediatR;
using System;
using TaskManagerPlatform.Application.Features.UserToTasks.Commands.CreateUserToTask;

namespace TaskManagerPlatform.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateUserToTaskCommand : IRequest<CreateUserToTaskCommandResponse>
    {
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }
    }
}