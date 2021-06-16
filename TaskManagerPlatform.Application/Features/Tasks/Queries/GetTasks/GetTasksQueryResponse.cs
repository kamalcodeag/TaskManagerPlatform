using System;

namespace TaskManagerPlatform.Application.Features.Tasks.Queries.GetTasks
{
    public class GetTasksQueryResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Guid? StatusId { get; set; }
    }
}