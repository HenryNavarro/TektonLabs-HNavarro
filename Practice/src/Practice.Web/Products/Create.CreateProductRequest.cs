using System.ComponentModel.DataAnnotations;

namespace Practice.Web.Endpoints.ProductEndpoints;
public class CreateProductRequest
{
  public const string Route = "/Products";

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
