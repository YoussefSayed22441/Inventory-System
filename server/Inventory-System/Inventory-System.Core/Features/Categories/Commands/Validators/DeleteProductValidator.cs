using FluentValidation;
using Inventory_System.Core.Features.Categories.Commands.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.Categories.Commands.Validators
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductValidator()
        {
            RuleFor(x=>x.Id)
                .NotEmpty().WithMessage("Product Id is required.");
        }
    }
}
