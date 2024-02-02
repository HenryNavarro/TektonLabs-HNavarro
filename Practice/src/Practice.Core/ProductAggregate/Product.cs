using Ardalis.SharedKernel;

namespace Practice.Core.ProductAggregate;
public class Product : IAggregateRoot
{
  public int ProductId { get; private set; }
  public string Name { get; private set; }
  public string Description { get; private set; }
  public decimal Price { get; private set; }
  public decimal Stock { get; private set; }
  public int Status { get; private set; }
  public decimal Discount { get; private set; }
  public decimal FinalPrice { get { return Price * (100 - Discount / 100); } }
  public Product(int productId, string name, string description, decimal stock, decimal price, decimal discount, int status)
  {
    this.ProductId = productId;
    this.Name = name;
    this.Description = description;
    this.Price = price;
    this.Stock = stock;
    this.Status = status;
    this.Discount = discount;

  }
  public void UpdateProduct(string name, string description, decimal price, decimal stock, int status)
  {
    this.Name = name;
    this.Description = description;
    this.Price = price;
    this.Stock = stock;
    this.Status = status;
  }
}
