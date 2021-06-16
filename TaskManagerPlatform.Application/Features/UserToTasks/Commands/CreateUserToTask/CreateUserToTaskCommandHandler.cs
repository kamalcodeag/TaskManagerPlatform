using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskManagerPlatform.Application.Contracts.Infrastructure;
using TaskManagerPlatform.Application.Contracts.Persistence;
using TaskManagerPlatform.Application.Features.UserToTasks.Commands.CreateUserToTask;
using TaskManagerPlatform.Application.Models.Mail;
using TaskManagerPlatform.Domain.Entities;

namespace TaskManagerPlatform.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateUserToTaskCommandHandler : IRequestHandler<CreateUserToTaskCommand, CreateUserToTaskCommandResponse>
    {
        private readonly IAsyncRepository<User> _userRepository;
        private readonly IAsyncRepository<Domain.Entities.Task> _taskRepository;
        private readonly IAsyncRepository<UserToTask> _userToTaskRepository;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public CreateUserToTaskCommandHandler(IEmailService emailService, IAsyncRepository<User> userRepository,
            IAsyncRepository<Domain.Entities.Task> taskRepository, IAsyncRepository<UserToTask> userToTaskRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _taskRepository = taskRepository;
            _userToTaskRepository = userToTaskRepository;
            _emailService = emailService;
            _mapper = mapper;
        }

        public async Task<CreateUserToTaskCommandResponse> Handle(CreateUserToTaskCommand request, CancellationToken cancellationToken)
        {
            CreateUserToTaskCommandResponse createUserToTaskCommandResponse = new CreateUserToTaskCommandResponse();

            CreateUserToTaskCommandValidator validator = new CreateUserToTaskCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createUserToTaskCommandResponse.Success = false;
                createUserToTaskCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    createUserToTaskCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createUserToTaskCommandResponse.Success)
            {
                User user = await _userRepository.GetByIdAsync(request.UserId);
                Domain.Entities.Task task = await _taskRepository.GetByIdAsync(request.TaskId);
                UserToTask newUserToTask = null;

                if (user != null && task != null)
                {
                    newUserToTask = new UserToTask
                    {
                        UserId = request.UserId,
                        TaskId = request.TaskId
                    };

                    newUserToTask = await _userToTaskRepository.AddAsync(newUserToTask);

                    Email email = new Email
                    {
                        To = user.Email,
                        Subject = "New task",
                        Body = "New task has been given to you."
                    };

                    await _emailService.SendEmail(email);

                    createUserToTaskCommandResponse = _mapper.Map<CreateUserToTaskCommandResponse>(newUserToTask);
                }
            }

            return createUserToTaskCommandResponse;
        }
    }
}