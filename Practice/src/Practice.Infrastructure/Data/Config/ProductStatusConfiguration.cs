using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Practice.Core.ProductStatusAggregate;

namespace Practice.Infrastructure.Data.Config;
public class ProductStatusConfiguration : IEntityTypeConfiguration<ProductStatus>
{
  public void Configure(EntityTypeBuilder<ProductStatus> builder)
  {
    builder.ToTable("ProductStatus");
    builder.HasKey(t => new { t.ProductStatusId });


    builder.Property(p => p.ProductStatusId)
        .ValueGeneratedNever()
        .IsRequired();

    builder.Property(p => p.Name)
        .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
        .IsRequired();
  }
}
