using FluentValidation;
using Inventory_System.Core.Features.Notifications.Queries.Models;

namespace Inventory_System.Core.Features.Notifications.Queries.Validators
{
    public class GetNotificationByIdValidator : AbstractValidator<GetNotificationByIdQuery>
    {
        public GetNotificationByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Notification Id is required.");
        }
    }
}