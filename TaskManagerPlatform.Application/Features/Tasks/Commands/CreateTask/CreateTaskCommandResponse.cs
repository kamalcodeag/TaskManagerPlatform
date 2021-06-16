using System;
using TaskManagerPlatform.Application.Responses;

namespace TaskManagerPlatform.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandResponse : BaseResponse
    {
        public CreateTaskCommandResponse() : base()
        {

        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
    }
}