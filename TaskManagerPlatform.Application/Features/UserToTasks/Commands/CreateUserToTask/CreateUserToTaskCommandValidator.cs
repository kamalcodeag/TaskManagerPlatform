using FluentValidation;

namespace TaskManagerPlatform.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateUserToTaskCommandValidator : AbstractValidator<CreateUserToTaskCommand>
    {
        public CreateUserToTaskCommandValidator()
        {
            RuleFor(utt => utt.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(utt => utt.TaskId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}