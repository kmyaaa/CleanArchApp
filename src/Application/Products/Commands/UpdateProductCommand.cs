using Application.Common;
using Application.Products.DTOs;
using Domain.Repositories;
using MediatR;

namespace Application.Products.Commands;

public record UpdateProductCommand(UpdateProductDto Product) : IRequest<Result<ProductDto>>;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result<ProductDto>>
{
    private readonly IProductRepository _repository;

    public UpdateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ProductDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existingProduct = await _repository.GetByIdAsync(request.Product.Id);
            if (existingProduct == null)
                return Result<ProductDto>.Failure("Product not found");

            existingProduct.Name = request.Product.Name;
            existingProduct.Description = request.Product.Description;
            existingProduct.Price = request.Product.Price;
            existingProduct.Stock = request.Product.Stock;
            existingProduct.IsActive = request.Product.IsActive;
            existingProduct.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(existingProduct);

            var productDto = new ProductDto(
                existingProduct.Id,
                existingProduct.Name,
                existingProduct.Description,
                existingProduct.Price,
                existingProduct.Stock,
                existingProduct.IsActive
            );

            return Result<ProductDto>.Success(productDto);
        }
        catch (Exception ex)
        {
            return Result<ProductDto>.Failure($"Failed to update product: {ex.Message}");
        }
    }
}