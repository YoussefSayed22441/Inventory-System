using Inventory_System.Service.Abstracts;
using AutoMapper;
using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Categories.Queries.DTOs;
using Inventory_System.Core.Features.Categories.Commands.Models;
using Inventory_System.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory_System.Core.Features.Categories.Commands.Handlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<CategoryDto>>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<Result<CategoryDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);
            var result = await _categoryService.AddAsync(category);

            if (result == null) return Result<CategoryDto>.Failure("Category Already Exists", ResultStatus.ValidationError);

            var dto = _mapper.Map<CategoryDto>(result);

            return Result<CategoryDto>.Created(dto, "Category Created Successfully");
        }
    }
}
