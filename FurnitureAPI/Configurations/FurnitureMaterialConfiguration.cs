using FurnitureAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FurnitureAPI.Configurations
{
  public class FurnitureMaterialConfiguration : IEntityTypeConfiguration<FurnitureMaterial>
  {
    public void Configure(EntityTypeBuilder<FurnitureMaterial> builder)
    {
      builder.ToTable("FurnitureMaterials", "Furniture");
      builder.HasKey(e => e.FurnitureMaterialId);

      builder.Property(u => u.FurnitureId)
        .IsRequired();

      builder.Property(u => u.MaterialId)
        .IsRequired();
    }
  }
}
