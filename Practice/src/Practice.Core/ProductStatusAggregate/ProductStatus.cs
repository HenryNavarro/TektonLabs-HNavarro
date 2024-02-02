using Ardalis.SharedKernel;
namespace Practice.Core.ProductStatusAggregate;

public class ProductStatus : IAggregateRoot
{
  public int ProductStatusId { get; private set; }
  public string Name { get; private set; }
  public ProductStatus(int productStatusId, string name)
  {
    this.ProductStatusId = productStatusId;
    this.Name = name;
  }
}
