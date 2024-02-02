using Ardalis.Result;
using FastEndpoints;
using MediatR;
using Practice.UseCases.Products.Get;
using Practice.UseCases.Products.Update;
using Practice.Web.Endpoints.ProductEndpoints;

namespace Practice.Web.ProductEndpoints;
public class Update(IMediator _mediator)
  : Endpoint<UpdateProductRequest, UpdateProductResponse>
{
  public override void Configure()
  {
    Put(UpdateProductRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    UpdateProductRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new UpdateProductCommand(request.Id, request.Name!, request.Description!, request.Price, request.Stock, request.Status));

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    var query = new GetProductQuery(request.Id);

    var queryResult = await _mediator.Send(query);

    if (queryResult.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (queryResult.IsSuccess)
    {
      var dto = queryResult.Value;
      Response = new UpdateProductResponse(new ProductRecord(dto.Id, dto.Name, dto.Description, dto.Price, dto.Stock, dto.StatusName));
      return;
    }
  }
}
