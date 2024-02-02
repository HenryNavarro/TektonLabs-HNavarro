using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Practice.UseCases.Products.Update;
public record UpdateProductCommand(int Id, string Name, string Description, decimal Price, decimal Stock, int Status) : ICommand<Result<ProductDTO>>;
