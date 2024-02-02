using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Practice.Core.ProductAggregate;
using Practice.Core.ProductStatusAggregate;

namespace Practice.Infrastructure.Data;
public static class SeedData
{
  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var dbContext = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
    {
      //  Look for any Contributors.
      //  if (dbContext.Products.Any())
      // {
      //   return;   // DB has been seeded
      // }

      PopulateTestData(dbContext);
    }
  }
  public static void PopulateTestData(AppDbContext dbContext)
  {
    foreach (var item in dbContext.Products)
      dbContext.Remove(item);
    foreach (var item in dbContext.ProductsStatus)
      dbContext.Remove(item);



    var random = new Random();
    for (var i = 1; i <= 10; i++)
    {
      dbContext.Products.Add(new Product(
        i + 1000
        , "Producto" + i
        , "Descripción de Producto de Prueba"
        , Math.Round((decimal)random.NextDouble(), 2) * 50
        , random.NextInt64(1000, 5000)
        , 0
        , 1
        ));
    }

    dbContext.ProductsStatus.Add(new ProductStatus(0, "Inactive"));
    dbContext.ProductsStatus.Add(new ProductStatus(1, "Active"));
    dbContext.SaveChanges();
  }
}
