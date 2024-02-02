using Ardalis.Result;
using Ardalis.SharedKernel;
using Practice.Core.ProductAggregate;

namespace Practice.UseCases.Products.Create;
public class CreateProductHandler(IRepository<Product> _repository)
  : ICommandHandler<CreateProductCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreateProductCommand request,
    CancellationToken cancellationToken)
  {
    var newProduct = new Product(request.Id, request.Name, request.Description, request.Stock, request.Price, 0,request.Status);
    var createdItem = await _repository.AddAsync(newProduct, cancellationToken);

    return createdItem.ProductId;
  }
}
