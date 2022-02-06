using FurnitureAPI.Data;
using FurnitureAPI.Models;
using Microsoft.AspNetCore.Identity;
using System.Globalization;

namespace FurnitureAPI.Seeders
{
  public class FurnitureSeeder
  {
    private readonly FurnitureDbContext _dbContext;
    private readonly IPasswordHasher<User> _passwordHasher;

    public FurnitureSeeder(FurnitureDbContext dbContext, IPasswordHasher<User> passwordHasher)
    {
      _dbContext = dbContext;
      _passwordHasher = passwordHasher;
    }

    public void Seed()
    {
      if (_dbContext.Database.CanConnect())
      {
        if (_dbContext.Roles.Any())
        {
          var roles = GetRoles();
          _dbContext.Roles.AddRange(roles);
          _dbContext.SaveChanges();
        }

        if (_dbContext.Users.Any())
        {
          var users = GetUsers();
          _dbContext.Users.AddRange(users);
          _dbContext.SaveChanges();
        }

        if (_dbContext.Furnitures.Any())
        {
          var furnitures = GetFurnitures();
          _dbContext.Furnitures.AddRange(furnitures);
          _dbContext.SaveChanges();
        }

        if (_dbContext.StatusOrders.Any())
        {
          var statusOrders = GetStatusOrders();
          _dbContext.StatusOrders.AddRange(statusOrders);
          _dbContext.SaveChanges();
        }

        if (_dbContext.Orders.Any())
        {
          var orders = GetOrders();
          _dbContext.Orders.AddRange(orders);
          _dbContext.SaveChanges();
        }

        if (_dbContext.Materials.Any())
        {
          var materials = GetMaterials();
          _dbContext.Materials.AddRange(materials);
          _dbContext.SaveChanges();
        }

        if (_dbContext.FurnitureMaterials.Any())
        {
          var furnitureMaterials = GetFurnitureMaterials();
          _dbContext.FurnitureMaterials.AddRange(furnitureMaterials);
          _dbContext.SaveChanges();
        }

        if (_dbContext.Employees.Any())
        {
          var employees = GetEmployees();
          _dbContext.Employees.AddRange(employees);
          _dbContext.SaveChanges();
        }

        if (_dbContext.Clients.Any())
        {
          var clients = GetClients();
          _dbContext.Clients.AddRange(clients);
          _dbContext.SaveChanges();
        }

        if (_dbContext.CategoryMaterials.Any())
        {
          var categoryMaterials = GetCategoryMaterials();
          _dbContext.CategoryMaterials.AddRange(categoryMaterials);
          _dbContext.SaveChanges();
        }

        if (_dbContext.CategoryFurnitures.Any())
        {
          var categoryFurnitures = GetCategoryFurnitures();
          _dbContext.CategoryFurnitures.AddRange(categoryFurnitures);
          _dbContext.SaveChanges();
        }
      }
    }

    private IEnumerable<Furniture> GetFurnitures()
    {
      return null;
    }

    private IEnumerable<User> GetUsers()
    {
      var user = new User
      {
        Login = "marcinkowalczyk24.7@gmail.com",
        UserFirstName = "Marcin",
        LastName = "Kowalczyk",
        DateOfBirth = DateTime.ParseExact("1999-06-10 16:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
        Nationality = "Polska",
        RoleId = 1
      };
      user.Password = _passwordHasher.HashPassword(user, "Marcingrafik1#");

      var user1 = new User
      {
        Login = "marcinkowalczyk24.5@wp.pl",
        UserFirstName = "Marcin",
        LastName = "Kowalczyk",
        DateOfBirth = DateTime.ParseExact("1999-06-10 16:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
        Nationality = "Polska",
        RoleId = 2
      };
      user1.Password = _passwordHasher.HashPassword(user1, "Marcingrafik1#");

      var user2 = new User
      {
        Login = "karol.strasburger@gmail.com",
        UserFirstName = "Karol",
        LastName = "Strasburger",
        DateOfBirth = DateTime.ParseExact("1959-03-29 16:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
        Nationality = "Polska",
        RoleId = 1
      };
      user2.Password = _passwordHasher.HashPassword(user2, "Marcingrafik1#");

      var users = new List<User>();
      users.Add(user);
      users.Add(user1);
      users.Add(user2);
      return users;
    }

    private IEnumerable<Role> GetRoles()
    {
      var roles = new List<Role>()
      {
        new Role()
        {
          RoleName = "User"
        },
        new Role()
        {
          RoleName = "Admin"
        }
      };

      return roles;
    }

    private IEnumerable<CategoryFurniture> GetCategoryFurnitures()
    {
      return null;
    }

    private IEnumerable<CategoryMaterial> GetCategoryMaterials()
    {
      return null;
    }

    private IEnumerable<Material> GetMaterials()
    {
      return null;
    }

    private IEnumerable<Client> GetClients()
    {
      return null;
    }

    private IEnumerable<FurnitureMaterial> GetFurnitureMaterials()
    {
      return null;
    }

    private IEnumerable<Order> GetOrders()
    {
      return null;
    }

    private IEnumerable<StatusOrder> GetStatusOrders()
    {
      return null;
    }

    private IEnumerable<Employee> GetEmployees()
    {
      return null;
    }
  }
}