using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskManagerPlatform.Application.Contracts.Persistence;

namespace TaskManagerPlatform.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, CreateTaskCommandResponse>
    {
        private readonly IAsyncRepository<Domain.Entities.Task> _taskRepository;
        private readonly IMapper _mapper;

        public CreateTaskCommandHandler(IAsyncRepository<Domain.Entities.Task> taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<CreateTaskCommandResponse> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            CreateTaskCommandResponse createTaskCommandResponse = new CreateTaskCommandResponse();

            CreateTaskCommandValidator validator = new CreateTaskCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createTaskCommandResponse.Success = false;
                createTaskCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    createTaskCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createTaskCommandResponse.Success)
            {
                Domain.Entities.Task newTask = new Domain.Entities.Task
                {
                    Title = request.Title,
                    Description = request.Description,
                    Deadline = request.Deadline
                };

                newTask = await _taskRepository.AddAsync(newTask);
                createTaskCommandResponse = _mapper.Map<CreateTaskCommandResponse>(newTask);
            }

            return createTaskCommandResponse;
        }
    }
}