using FastEndpoints;
using FluentValidation;
using Practice.Infrastructure.Data.Config;

namespace Practice.Web.Endpoints.ProductEndpoints;
/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class CreateProductValidator : Validator<CreateProductRequest>
{
  public CreateProductValidator()
  {
    RuleFor(x => x.Id)
      .NotEmpty()
      .WithMessage("Id is required.");

    RuleFor(x => x.Name)
      .NotEmpty()
      .WithMessage("Name is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);

    RuleFor(x => x.Description)
      .NotEmpty()
      .WithMessage("Description is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_DESCRIPTION_LENGTH);

    RuleFor(x => x.Price)
      .NotEmpty()
      .WithMessage("Price is required.");

    RuleFor(x => x.Stock)
      .NotEmpty()
      .WithMessage("Stock is required.");

    RuleFor(x => x.Status)
      .NotEmpty();
  }
}
