using System;
using TaskManagerPlatform.Application.Responses;

namespace TaskManagerPlatform.Application.Features.UserToTasks.Commands.CreateUserToTask
{
    public class CreateUserToTaskCommandResponse : BaseResponse
    {
        public CreateUserToTaskCommandResponse() : base()
        {

        }

        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }
    }
}