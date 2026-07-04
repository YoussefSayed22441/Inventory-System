using FluentValidation;
using Inventory_System.Core.Features.Products.Queries.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.Products.Queries.Validators
{
    public class GetProductsByCategoryValidator : AbstractValidator<GetProductsByCategoryQuery>
    {
        public GetProductsByCategoryValidator()
        {
            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Category ID is required.");
        }
    }
}
