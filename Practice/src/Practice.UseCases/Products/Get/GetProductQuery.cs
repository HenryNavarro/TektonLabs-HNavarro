using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Practice.UseCases.Products.Get;
public record GetProductQuery(int Id) : IQuery<Result<ProductDTO>>;
