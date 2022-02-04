using FurnitureAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FurnitureAPI.Configurations
{
  public class StatusOrderConfiguration : IEntityTypeConfiguration<StatusOrder>
  {
    public void Configure(EntityTypeBuilder<StatusOrder> builder)
    {
      builder.ToTable("StatusOrders", "Furniture");
      builder.HasKey(e => e.IdStatusOrder);
      builder.Property(u => u.StatusOrderName)
        .IsRequired()
        .HasMaxLength(80);
    }
  }
}
