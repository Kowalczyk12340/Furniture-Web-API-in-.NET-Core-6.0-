using FurnitureAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FurnitureAPI.Configurations
{
  public class CategoryFurnitureConfiguration : IEntityTypeConfiguration<CategoryFurniture>
  {
    public void Configure(EntityTypeBuilder<CategoryFurniture> builder)
    {
      builder.ToTable("CategoryFurnitures", "Furniture");
      builder.HasKey(e => e.CategoryFurnitureId);
      builder.Property(u => u.CategoryFurnitureName)
        .IsRequired()
        .HasMaxLength(80);
    }
  }
}