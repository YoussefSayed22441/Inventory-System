using FluentValidation;
using Inventory_System.Core.Features.Categories.Queries.Models;
namespace Inventory_System.Core.Features.Suppliers.Queries.Validators
{
    public class GetSupplierByIdValidator : AbstractValidator<GetSupplierByIdQuery>
    {
        public GetSupplierByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Supplier Id is required.");
        }
    }
}
