using Application.Common;
using Application.Products.DTOs;
using Domain.Repositories;
using MediatR;

namespace Application.Products.Queries;

public record GetAllProductsQuery : IRequest<Result<IEnumerable<ProductDto>>>;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, Result<IEnumerable<ProductDto>>>
{
    private readonly IProductRepository _repository;

    public GetAllProductsQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<ProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var products = await _repository.GetAllAsync();
            var productDtos = products.Select(p => new ProductDto(
                p.Id,
                p.Name,
                p.Description,
                p.Price,
                p.Stock,
                p.IsActive
            ));

            return Result<IEnumerable<ProductDto>>.Success(productDtos);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<ProductDto>>.Failure($"Failed to get products: {ex.Message}");
        }
    }
}