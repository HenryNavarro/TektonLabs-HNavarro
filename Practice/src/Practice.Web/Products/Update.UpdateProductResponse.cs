using Practice.Web.ProductEndpoints;

namespace Practice.Web.Endpoints.ProductEndpoints;
public class UpdateProductResponse
{
  public UpdateProductResponse(ProductRecord product)
  {
    Product = product;
  }
  public ProductRecord Product { get; set; }
}
