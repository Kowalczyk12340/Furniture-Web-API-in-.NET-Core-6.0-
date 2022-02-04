using FurnitureAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FurnitureAPI.Configurations
{
  public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
  {
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
      builder.ToTable("Employees", "Furniture");
      builder.HasKey(e => e.IdEmployee);
      builder.Property(u => u.EmployeeName)
        .IsRequired()
        .HasMaxLength(50);

      builder.Property(u => u.EmployeeSurname)
        .IsRequired()
        .HasMaxLength(80);

      builder.Property(u => u.EmployeeEmail)
        .IsRequired()
        .HasMaxLength(80);

      builder.Property(u => u.EmployeeSeniority)
        .IsRequired();
    }
  }
}
