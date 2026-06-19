using Inventory_System.Service.Abstracts;
using AutoMapper;
using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Categories.Commands.Models;
using Inventory_System.Core.Features.Categories.Queries.DTOs;
using Inventory_System.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory_System.Core.Features.Categories.Commands.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result<CategoryDto>>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<Result<CategoryDto>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var existingCategory = await _categoryService.GetByIdAsync(request.Id); 
            if (existingCategory == null) return Result<CategoryDto>.Failure("Category Not Found", ResultStatus.NotFound);

            _mapper.Map(request, existingCategory);

            var result = await _categoryService.UpdateAsync(existingCategory);

            if (result == null) return Result<CategoryDto>.Failure("Category Update Failed", ResultStatus.ValidationError);

            var dto = _mapper.Map<CategoryDto>(result);

            return Result<CategoryDto>.Success(dto, "Category Updated Successfully");
        }
    }
}
