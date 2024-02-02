using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Practice.Core.ProductAggregate;

namespace Practice.Infrastructure.Data.Config;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
  public void Configure(EntityTypeBuilder<Product> builder)
  {

    builder.ToTable("Product");
    builder.HasKey(t => new { t.ProductId });

    builder.Property(p => p.ProductId)
        .IsRequired();

    builder.Property(p => p.Name)
        .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
        .IsRequired();

    builder.Property(p => p.Description)
        .HasMaxLength(DataSchemaConstants.DEFAULT_DESCRIPTION_LENGTH)
        .IsRequired();

    builder.Property(p => p.Stock)
        .HasDefaultValue(0)
        .IsRequired(); ;

    builder.Property(p => p.Price)
        .HasDefaultValue(0)
        .IsRequired(); ;

    builder.Property(p => p.Status)
        .HasDefaultValue(1)
        .IsRequired();
  }
}
