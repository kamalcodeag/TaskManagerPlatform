using AutoMapper;
using TaskManagerPlatform.Application.Features.Tasks.Commands.CreateTask;
using TaskManagerPlatform.Application.Features.Tasks.Queries.GetTasks;
using TaskManagerPlatform.Application.Features.UserToTasks.Commands.CreateUserToTask;
using TaskManagerPlatform.Domain.Entities;

namespace TaskManagerPlatform.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Task, GetTasksQueryResponse>().ReverseMap();
            CreateMap<Task, CreateTaskCommandResponse>().ReverseMap();
            CreateMap<UserToTask, CreateUserToTaskCommandResponse>().ReverseMap();
        }
    }
}