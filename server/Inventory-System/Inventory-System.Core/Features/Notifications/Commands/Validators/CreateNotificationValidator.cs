using FluentValidation;
using Inventory_System.Core.Features.Notifications.Commands.Models;

namespace Inventory_System.Core.Features.Notifications.Commands.Validators
{
    public class CreateNotificationValidator : AbstractValidator<CreateNotificationCommand>
    {
        public CreateNotificationValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("Title max length is 200.");

            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Message is required.")
                .NotNull()
                .MaximumLength(1000).WithMessage("Message max length is 1000.");

            RuleFor(x => x.Type)
                .IsInEnum().WithMessage("Invalid Notification Type.");

            RuleFor(x => x.Priority)
                .IsInEnum().WithMessage("Invalid Notification Priority.");

            RuleFor(x => x.Notes)
                .MaximumLength(500).WithMessage("Notes max length is 500.")
                .When(x => x.Notes != null);
        }
    }

    public class DeleteNotificationValidator : AbstractValidator<DeleteNotificationCommand>
    {
        public DeleteNotificationValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Notification Id is required.");
        }
    }

    public class MarkNotificationAsReadValidator : AbstractValidator<MarkNotificationAsReadCommand>
    {
        public MarkNotificationAsReadValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Notification Id is required.");
        }
    }
}