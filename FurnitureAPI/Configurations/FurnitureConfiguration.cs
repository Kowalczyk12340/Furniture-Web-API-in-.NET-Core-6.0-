using FurnitureAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FurnitureAPI.Configurations
{
  public class FurnitureConfiguration : IEntityTypeConfiguration<Furniture>
  {
    public void Configure(EntityTypeBuilder<Furniture> builder)
    {
      builder.ToTable("Furnitures", "Furniture");
      builder.HasKey(e => e.FurnitureId);
      builder.Property(u => u.FurnitureName)
        .IsRequired()
        .HasMaxLength(50);

      builder.Property(u => u.FurnitureWidth)
        .IsRequired();

      builder.Property(u => u.FurnitureHeight)
        .IsRequired();

      builder.Property(u => u.FurnitureDepth)
        .IsRequired();
    }
  }
}
