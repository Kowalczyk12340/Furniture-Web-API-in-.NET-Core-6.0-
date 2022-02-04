using FurnitureAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FurnitureAPI.Data
{
  public class FurnitureDbContext : DbContext
  {
    private readonly IMediator _mediator;
    public FurnitureDbContext(DbContextOptions<FurnitureDbContext> options, IMediator mediator) : base(options)
    {
      _mediator = mediator;
    }

    public DbSet<AuthToken> AuthTokens { get; set; }
    public DbSet<CategoryFurniture> CategoryFurnitures { get; set; }
    public DbSet<CategoryMaterial> CategoryMaterials { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Furniture> Furnitures { get; set; }
    public DbSet<FurnitureMaterial> FurnitureMaterials { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<StatusOrder> StatusOrders { get; set; }
    public DbSet<User> Users { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
      var entities = ChangeTracker.Entries<DomainEntity>().ToList();

      var events = new List<INotification>();
      foreach (var entity in entities)
      {
        var domainEntity = entity.Entity;

        events.AddRange(domainEntity.Events);
        domainEntity.ClearEvents();
      }

      var result = await base.SaveChangesAsync(cancellationToken);

      foreach (var @event in events)
      {
        await _mediator.Publish(@event, cancellationToken);
      }

      return result;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
  }

  public static class SportDbContextExtensions
  {
    public static IServiceCollection AddSportDbContext(this IServiceCollection services, string connection)
    {
      services.AddDbContext<FurnitureDbContext>(options => { options.UseSqlServer(connection); });

      return services;
    }
  }
}
