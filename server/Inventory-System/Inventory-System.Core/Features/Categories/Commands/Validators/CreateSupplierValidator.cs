using FluentValidation;
using Inventory_System.Core.Features.Categories.Commands.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Features.Categories.Commands.Validators
{
    public class CreateSupplierValidator : AbstractValidator<CreateSupplierCommand>
    {
        public CreateSupplierValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Supplier Name is required")
            .NotNull()
            .MaximumLength(150).WithMessage("Supplier Name max length is 150");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is not valid")
                .MaximumLength(200).WithMessage("Email max length is 200");
            
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone is required")
                .MaximumLength(20).WithMessage("Phone max length is 20");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required")
                .MaximumLength(500).WithMessage("Address max length is 500");
        }
        
    }
}
