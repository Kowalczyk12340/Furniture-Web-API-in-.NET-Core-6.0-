using FurnitureAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FurnitureAPI.Configurations
{
  public class CategoryMaterialConfiguration : IEntityTypeConfiguration<CategoryMaterial>
  {
    public void Configure(EntityTypeBuilder<CategoryMaterial> builder)
    {
      builder.ToTable("CategoryMaterials", "Furniture");
      builder.HasKey(e => e.IdCategoryMaterial);
      builder.Property(u => u.CategoryMaterialName)
        .IsRequired()
        .HasMaxLength(80);
    }
  }
}
