using FluentValidation;
using System;

namespace TaskManagerPlatform.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(t => t.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(t => t.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(t => t.Deadline)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(DateTime.Now);
        }
    }
}