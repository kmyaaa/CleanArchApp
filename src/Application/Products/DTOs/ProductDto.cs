namespace Application.Products.DTOs;

public record ProductDto(
    int Id,
    string Name,
    string Description,
    decimal Price,
    int Stock,
    bool IsActive
);

public record CreateProductDto(
    string Name,
    string Description,
    decimal Price,
    int Stock
);

public record UpdateProductDto(
    int Id,
    string Name,
    string Description,
    decimal Price,
    int Stock,
    bool IsActive
);