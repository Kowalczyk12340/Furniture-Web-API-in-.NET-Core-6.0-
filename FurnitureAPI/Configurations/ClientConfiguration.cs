using FurnitureAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FurnitureAPI.Configurations
{
  public class ClientConfiguration : IEntityTypeConfiguration<Client>
  {
    public void Configure(EntityTypeBuilder<Client> builder)
    {
      builder.ToTable("Clients", "Furniture");
      builder.HasKey(e => e.ClientId);
      builder.Property(u => u.ClientName)
        .IsRequired()
        .HasMaxLength(50);

      builder.Property(u => u.ClientSurname)
        .IsRequired()
        .HasMaxLength(80);

      builder.Property(u => u.ClientEmail)
        .IsRequired()
        .HasMaxLength(80);
    }
  }
}
