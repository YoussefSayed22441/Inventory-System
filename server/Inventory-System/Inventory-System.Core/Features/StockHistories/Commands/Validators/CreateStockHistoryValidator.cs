using FluentValidation;
using Inventory_System.Core.Features.StockHistories.Commands.Models;


namespace Inventory_System.Core.Features.StockHistories.Commands.Validators
{
    public class CreateStockHistoryValidator : AbstractValidator<CreateStockHistoryCommand>
    {
        public CreateStockHistoryValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Product Id is required.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");

            RuleFor(x => x.Type)
                .IsInEnum().WithMessage("Invalid Transaction Type.");

            RuleFor(x => x.Notes)
                .MaximumLength(500).WithMessage("Notes max length is 500.")
                .When(x => x.Notes != null);
        }
    }
}