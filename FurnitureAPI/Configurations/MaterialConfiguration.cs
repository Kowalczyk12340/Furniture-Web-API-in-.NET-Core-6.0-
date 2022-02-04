using FurnitureAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FurnitureAPI.Configurations
{
  public class MaterialConfiguration : IEntityTypeConfiguration<Material>
  {
    public void Configure(EntityTypeBuilder<Material> builder)
    {
      builder.ToTable("Materials", "Furniture");
      builder.HasKey(e => e.IdMaterial);
      builder.Property(u => u.MaterialName)
        .IsRequired()
        .HasMaxLength(50);

      builder.Property(u => u.MaterialStockStatus)
        .IsRequired();

      builder.Property(u => u.MaterialPrice)
        .IsRequired().HasDefaultValue(0);
    }
  }
}
