using FluentValidation;
using Inventory_System.Core.Features.Products.Queries.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.Products.Queries.Validators
{
    public class GetProductByIdValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdValidator() 
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Product ID is required.");
        }
    }
}
