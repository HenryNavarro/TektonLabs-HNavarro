using FastEndpoints;
using FluentValidation;
using Practice.Infrastructure.Data.Config;

namespace Practice.Web.Endpoints.ProductEndpoints;
/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class UpdateProductValidator : Validator<UpdateProductRequest>
{
  public UpdateProductValidator()
  {
    RuleFor(x => x.Id)
      .Must((args, Id) => args.Id == Id)
      .WithMessage("Route and body Ids must match; cannot update Id of an existing resource.");

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
