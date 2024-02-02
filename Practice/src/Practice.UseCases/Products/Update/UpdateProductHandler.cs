using Ardalis.Result;
using Ardalis.SharedKernel;
using Practice.Core.ProductAggregate;

namespace Practice.UseCases.Products.Update;
public class UpdateProductHandler(IRepository<Product> _repository)
  : ICommandHandler<UpdateProductCommand, Result<ProductDTO>>
{
  public async Task<Result<ProductDTO>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
  {
    var existingEntity = await _repository.GetByIdAsync(request.Id, cancellationToken);
    if (existingEntity == null)
    {
      return Result.NotFound();
    }

    existingEntity.UpdateProduct(request.Name!, request.Description!, request.Price!, request.Stock, request.Status);
    await _repository.UpdateAsync(existingEntity, cancellationToken);

    var status = await _repository.GetByIdAsync(existingEntity.Status, cancellationToken);
    if (status == null) return Result.NotFound("Status Key Not Found");


    return Result.Success(new ProductDTO(existingEntity.ProductId, existingEntity.Name, existingEntity.Description, existingEntity.Price, existingEntity.Discount, existingEntity.FinalPrice, existingEntity.Stock, status.Name));
  }
}
