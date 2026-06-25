using FluentValidation;
using Inventory_System.Core.Features.ProductSupplier.Queries.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.ProductSupplier.Queries.Validators
{
    public class GetProductsBySupplierValidator : AbstractValidator<GetProductsBySupplierQuery>
    {
        public GetProductsBySupplierValidator()
        {
            RuleFor(x => x.SupplierId)
                .NotEmpty().WithMessage("Supplier Id is Required");
        }
    }
}
