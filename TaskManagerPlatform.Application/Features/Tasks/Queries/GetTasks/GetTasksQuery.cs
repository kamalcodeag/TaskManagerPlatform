using MediatR;
using System.Collections.Generic;

namespace TaskManagerPlatform.Application.Features.Tasks.Queries.GetTasks
{
    public class GetTasksQuery : IRequest<List<GetTasksQueryResponse>>
    {
    }
}