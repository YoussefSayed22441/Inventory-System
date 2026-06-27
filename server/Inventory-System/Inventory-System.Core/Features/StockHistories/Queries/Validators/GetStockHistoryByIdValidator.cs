using FluentValidation;
using Inventory_System.Core.Features.StockHistories.Queries.Models;


namespace Inventory_System.Core.Features.StockHistories.Queries.Validators
{
    public class GetStockHistoryByIdValidator : AbstractValidator<GetStockHistoryByIdQuery>
    {
        public GetStockHistoryByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Stock History Id is required.");
        }
    }
}