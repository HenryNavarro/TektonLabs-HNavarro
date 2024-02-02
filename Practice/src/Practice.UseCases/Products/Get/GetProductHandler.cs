using Ardalis.Result;
using Ardalis.SharedKernel;
using Ardalis.Specification;
using Practice.Core.ProductAggregate;
using Practice.Core.ProductAggregate.Specifications;
using Practice.Core.ProductStatusAggregate;


namespace Practice.UseCases.Products.Get;
/// <summary>
/// Queries don't necessarily need to use repository methods, but they can if it's convenient
/// </summary>
public class GetProductHandler(IReadRepository<Product> _repository, IReadOnlyRepository<ProductStatus> _repositoryStatus)
  : IQueryHandler<GetProductQuery, Result<ProductDTO>>
{
  public async Task<Result<ProductDTO>> Handle(GetProductQuery request, CancellationToken cancellationToken)
  {

    var entity = await _repository.FirstOrDefaultAsync(new ProductByIdSpec(request.Id), cancellationToken);
    if (entity == null) return Result.NotFound();

    var status = await _repositoryStatus.GetByIdAsync(entity.Status);
    if (status == null) return Result.NotFound("Status Key Not Found");

    return new ProductDTO(entity.ProductId, entity.Name, entity.Description, entity.Price, entity.Discount, entity.FinalPrice, entity.Stock, status.Name);
  }
}
