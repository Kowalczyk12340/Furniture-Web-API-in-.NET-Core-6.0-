using FurnitureAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FurnitureAPI.Configurations
{
  public class AuthTokenConfiguration : IEntityTypeConfiguration<AuthToken>
  {
    public void Configure(EntityTypeBuilder<AuthToken> builder)
    {
      builder.ToTable("AuthTokens", "Furniture");
      builder.HasKey(e => e.Id);
      builder.Property(e => e.Id).HasDefaultValueSql("NEWID()");
      builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
    }
  }
}
