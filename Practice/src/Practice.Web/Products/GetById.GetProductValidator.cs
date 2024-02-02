using FastEndpoints;
using FluentValidation;

namespace Practice.Web.Endpoints.ProductEndpoints;
/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class GetProductValidator : Validator<GetProductByIdRequest>
{
  public GetProductValidator()
  {
    RuleFor(x => x.Id)
      .GreaterThan(0);
  }
}
