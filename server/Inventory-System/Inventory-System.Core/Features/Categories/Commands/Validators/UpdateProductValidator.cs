using FluentValidation;
using Inventory_System.Core.Features.Categories.Commands.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.Categories.Commands.Validators
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Product Id is required.");

            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product Name is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("Product Name max length is 200.");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description max length is 1000.");

            RuleFor(x => x.SKU)
                .MaximumLength(100).WithMessage("SKU max length is 100.");

            RuleFor(x => x.Barcode)
                .MaximumLength(100).WithMessage("Barcode max length is 100.");

            RuleFor(x => x.SellingPrice)
                .GreaterThan(0).WithMessage("Selling Price must be greater than 0.");

            RuleFor(x => x.CostPrice)
                .GreaterThan(0).WithMessage("Cost Price must be greater than 0.");

            RuleFor(x => x.CurrentStock)
                .GreaterThanOrEqualTo(0).WithMessage("Current Stock cannot be negative.");

            RuleFor(x => x.ReorderLevel)
                .GreaterThanOrEqualTo(0).WithMessage("Reorder Level cannot be negative.");

            RuleFor(x => x.MinStockLevel)
                .GreaterThanOrEqualTo(0).WithMessage("Min Stock Level cannot be negative.");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Category Id is required.");
        }
    }
}
