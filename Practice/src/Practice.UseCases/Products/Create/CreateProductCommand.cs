using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Practice.UseCases.Products.Create;
/// <summary>
/// Create Product
/// </summary>
/// <param name="Id"></param>
/// <param name="Name"></param>
/// <param name="Description"></param>
/// <param name="Price"></param>
/// <param name="Stock"></param>
/// <param name="Status"></param>
public record CreateProductCommand(int Id, string Name, string Description, decimal Price, decimal Stock, int Status) : ICommand<Result<int>>;
