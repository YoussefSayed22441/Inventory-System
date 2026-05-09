using AutoMapper;
using AutoMapper.QueryableExtensions;
using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.Categories.Queries.DTOs;
using Inventory_System.Core.Features.Categories.Queries.Models;
using Inventory_System.Core.Wrapper;
using Inventory_System.Service.Abstracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory_System.Core.Features.Categories.Queries.Handles
{
    internal class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, Result<PaginatedResult<CategoryDto>>>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<Result<PaginatedResult<CategoryDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var query = _categoryService.GetCategories();
            var totalCount = await query.CountAsync();


            var data = query
                .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var paginated = PaginatedResult<CategoryDto>
               .Success(data, request.PageNumber, totalCount, request.PageSize);

            return Result<PaginatedResult<CategoryDto>>.Success(paginated);

        }
    }
}
