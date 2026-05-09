using FluentValidation;
using Inventory_System.Core.Features.Categories.Commands.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.Categories.Commands.Validators
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Category Id is required");

            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Category Name is required")
                .NotNull()
                .MaximumLength(100).WithMessage("Category Name max length is 100");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description max length is 500");
        }
    }
}