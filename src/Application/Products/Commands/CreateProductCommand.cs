using Application.Common;
using Application.Products.DTOs;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Products.Commands;

public record CreateProductCommand(CreateProductDto Product) : IRequest<Result<ProductDto>>;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<ProductDto>>
{
    private readonly IProductRepository _repository;

    public CreateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var product = new Product
            {
                Name = request.Product.Name,
                Description = request.Product.Description,
                Price = request.Product.Price,
                Stock = request.Product.Stock,
                CreatedAt = DateTime.UtcNow
            };

            var createdProduct = await _repository.AddAsync(product);

            var productDto = new ProductDto(
                createdProduct.Id,
                createdProduct.Name,
                createdProduct.Description,
                createdProduct.Price,
                createdProduct.Stock,
                createdProduct.IsActive
            );

            return Result<ProductDto>.Success(productDto);
        }
        catch (Exception ex)
        {
            return Result<ProductDto>.Failure($"Failed to create product: {ex.Message}");
        }
    }
}