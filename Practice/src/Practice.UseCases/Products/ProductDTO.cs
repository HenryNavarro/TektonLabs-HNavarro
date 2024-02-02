namespace Practice.UseCases.Products;
public record ProductDTO(int Id, string Name, string Description, decimal Price,decimal Discount, decimal FinalPrice, decimal Stock, string StatusName);
