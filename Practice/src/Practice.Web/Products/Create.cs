using FastEndpoints;
using MediatR;
using Practice.UseCases.Products.Create;
using Practice.Web.Endpoints.ProductEndpoints;

namespace Practice.Web.ProductEndpoints;

public class Create(IMediator _mediator)
  : Endpoint<CreateProductRequest, CreateProductResponse>
{
  public override void Configure()
  {
    Post(CreateProductRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    CreateProductRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreateProductCommand(request.Id, request.Name!, request.Description!, request.Price, request.Stock, request.Status));

    if (result.IsSuccess)
    {
      Response = new CreateProductResponse(result.Value);
      return;
    }
    // TODO: Handle other cases as necessary
  }
}
