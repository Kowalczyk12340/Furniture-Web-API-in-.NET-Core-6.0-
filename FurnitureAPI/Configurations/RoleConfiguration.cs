using FurnitureAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FurnitureAPI.Configurations
{
  public class RoleConfiguration : IEntityTypeConfiguration<Role>
  {
    public void Configure(EntityTypeBuilder<Role> builder)
    {
      builder.ToTable("Roles", "Furniture");
      builder.HasKey(e => e.IdRole);
      builder.Property(u => u.RoleName)
        .IsRequired()
        .HasMaxLength(40);
    }
  }
}
