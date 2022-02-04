using FurnitureAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FurnitureAPI.Configurations
{
  public class OrderConfiguration : IEntityTypeConfiguration<Order>
  {
    public void Configure(EntityTypeBuilder<Order> builder)
    {
      builder.ToTable("Orders", "Furniture");
      builder.HasKey(e => e.IdOrder);
      builder.Property(u => u.OrderCode)
        .IsRequired()
        .HasMaxLength(100);

      builder.Property(u => u.OrderPayment)
        .IsRequired();

      builder.Property(u => u.OrderDateSubmission)
        .IsRequired().HasDefaultValue(DateTime.UtcNow);
    }
  }
}
