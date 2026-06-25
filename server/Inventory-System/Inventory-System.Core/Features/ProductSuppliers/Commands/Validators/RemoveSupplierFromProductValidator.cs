using FluentValidation;
using Inventory_System.Core.Features.ProductSupplier.Commands.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.ProductSuppliers.Commands.Validators
{
    public class RemoveSupplierFromProductValidator : AbstractValidator<RemoveSupplierFromProductCommand>
    {
        public RemoveSupplierFromProductValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Product Id is required.");

            RuleFor(x => x.SupplierId)
                .NotEmpty().WithMessage("Supplier Id is required.");
        }
    }
}
