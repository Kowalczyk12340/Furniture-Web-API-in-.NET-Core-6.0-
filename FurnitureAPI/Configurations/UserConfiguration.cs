using FurnitureAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FurnitureAPI.Configurations
{
  public class UserConfiguration : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.ToTable("Users", "Furniture");
      builder.HasKey(e => e.IdUser);
      builder.Property(u => u.UserFirstName)
        .IsRequired()
        .HasMaxLength(50);
      builder.Property(u => u.LastName)
        .IsRequired()
        .HasMaxLength(30);
      builder.Property(u => u.Login)
        .IsRequired()
        .HasMaxLength(50);
      builder.Property(u => u.Password)
        .IsRequired()
        .HasMaxLength(30);
    }
  }
}
