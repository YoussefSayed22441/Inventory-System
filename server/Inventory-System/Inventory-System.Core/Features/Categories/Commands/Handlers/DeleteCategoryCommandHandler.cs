using Inventory_System.Service.Abstracts;
using AutoMapper;
using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Categories.Commands.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory_System.Core.Features.Categories.Commands.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Result<bool>>
    {
        private readonly ICategoryService _categoryService;

        public DeleteCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<Result<bool>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetByIdAsync(request.Id);
            if (category == null) return Result<bool>.Failure("Category Not Found", ResultStatus.NotFound);

            var result = await _categoryService.DeleteAsync(category);

            if (!result) return Result<bool>.Failure("Category Delete Failed", ResultStatus.ValidationError);

            return Result<bool>.Success(true, "Category Deleted Successfully");
        }
    }
}
