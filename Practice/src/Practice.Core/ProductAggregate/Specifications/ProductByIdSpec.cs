using Ardalis.Specification;

namespace Practice.Core.ProductAggregate.Specifications;
public class ProductByIdSpec : Specification<Product>
{
  public ProductByIdSpec(int productId)
  {
    Query. Where(x => x.ProductId == productId);
  }
}
