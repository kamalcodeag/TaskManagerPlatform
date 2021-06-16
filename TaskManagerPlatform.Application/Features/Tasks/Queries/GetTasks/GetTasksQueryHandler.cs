using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskManagerPlatform.Application.Contracts.Persistence;

namespace TaskManagerPlatform.Application.Features.Tasks.Queries.GetTasks
{
    public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, List<GetTasksQueryResponse>>
    {
        private readonly IAsyncRepository<Domain.Entities.Task> _taskRepository;
        private readonly IMapper _mapper;

        public GetTasksQueryHandler(IAsyncRepository<Domain.Entities.Task> taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<List<GetTasksQueryResponse>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Domain.Entities.Task> allTasks = await _taskRepository.ListAllAsync();
            return _mapper.Map<List<GetTasksQueryResponse>>(allTasks);
        }
    }
}