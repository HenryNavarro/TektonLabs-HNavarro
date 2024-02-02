namespace Practice.Web.Endpoints.ProductEndpoints;

public class GetProductByIdRequest
{
  public const string Route = "/Products/{Id:int}";
  public static string BuildRoute(int Id) => Route.Replace("{Id:int}", Id.ToString());

  public int Id { get; set; }
}
