using FluentValidation;
using Inventory_System.Core.Features.ProductSupplier.Queries.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.ProductSupplier.Queries.Validators
{
    public class GetSuppliersByProductValidator : AbstractValidator<GetSuppliersByProductQuery>
    {
        public GetSuppliersByProductValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Product Id is required.");
        }
    }
}
