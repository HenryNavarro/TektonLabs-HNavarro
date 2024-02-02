using System.ComponentModel.DataAnnotations;

namespace Practice.Web.Endpoints.ProductEndpoints;
public class UpdateProductRequest
{
  public const string Route = "/Products/{Id:int}";
  public static string BuildRoute(int Id) => Route.Replace("{Id:int}", Id.ToString());

  [Required]
  public int Id { get; set; }

  [Required]
  public string? Name { get; set; }

  [Required]
  public string? Description { get; set; }

  [Required]
  public decimal Price { get; set; }

  [Required]
  public decimal Stock { get; set; }

  [Required]
  public int Status { get; set; }
}
