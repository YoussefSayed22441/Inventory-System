using FluentValidation;
using Inventory_System.Core.Features.Suppliers.Commands.Models;

namespace Inventory_System.Core.Features.Suppliers.Commands.Validators
{
    public class DeleteSupplierValidator : AbstractValidator<DeleteSupplierCommand>
    {
        public DeleteSupplierValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Supplier Id is required.");
        }
    }
}
