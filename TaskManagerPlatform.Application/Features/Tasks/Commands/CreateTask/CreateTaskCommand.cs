using MediatR;
using System;

namespace TaskManagerPlatform.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<CreateTaskCommandResponse>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
    }
}