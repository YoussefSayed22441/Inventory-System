using AutoMapper;
using Inventory_System.Core.Bases;
using Inventory_System.Core.Features.StockHistories.Commands.Models;
using Inventory_System.Core.Features.StockHistories.Queries.DTOs;
using Inventory_System.Domain.Entities;
using Inventory_System.Domain.Helpers;
using Inventory_System.Service.Abstracts;
using MediatR;


namespace Inventory_System.Core.Features.StockHistories.Commands.Handlers
{
    public class CreateStockHistoryCommandHandler
        : IRequestHandler<CreateStockHistoryCommand, Result<StockHistoryDto>>
    {
        private readonly IStockHistoryService _stockHistoryService;
        private readonly IMapper _mapper;

        public CreateStockHistoryCommandHandler(IStockHistoryService stockHistoryService, IMapper mapper)
        {
            _stockHistoryService = stockHistoryService;
            _mapper = mapper;
        }

        public async Task<Result<StockHistoryDto>> Handle(
            CreateStockHistoryCommand request, CancellationToken cancellationToken)
        {
            var stockHistory = _mapper.Map<StockHistory>(request);
            var result = await _stockHistoryService.AddAsync(stockHistory);

            if (result == null)
            {
                // Distinguish between product not found and insufficient stock
                if (request.Type == TransactionType.OUT)
                    return Result<StockHistoryDto>.Failure(
                        "Insufficient stock or Product Not Found.",
                        ResultStatus.ValidationError);

                return Result<StockHistoryDto>.Failure(
                    "Product Not Found.",
                    ResultStatus.NotFound);
            }

            var dto = _mapper.Map<StockHistoryDto>(result);
            return Result<StockHistoryDto>.Created(dto, "Stock Transaction Recorded Successfully.");
        }
    }
}