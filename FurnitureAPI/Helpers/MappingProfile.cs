using AutoMapper;
using FurnitureAPI.Dtos;
using FurnitureAPI.Dtos.Create;
using FurnitureAPI.Dtos.Update;
using FurnitureAPI.Models;
using System.Reflection;

namespace FurnitureAPI.Helpers
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Client, ClientDto>();

      CreateMap<CategoryFurniture, CategoryFurnitureDto>();
      CreateMap<CategoryMaterial, CategoryMaterialDto>();

      CreateMap<Employee, EmployeeDto>();
      CreateMap<Furniture, FurnitureDto>();
      CreateMap<FurnitureMaterial, FurnitureMaterialDto>();

      CreateMap<Material, MaterialDto>();
      CreateMap<Order, OrderDto>();
      CreateMap<StatusOrder, StatusOrderDto>();

      CreateMap<User, UserDto>()
        .ForMember(m => m.RoleName, c => c.MapFrom(s => s.Role.RoleName));

      CreateMap<Role, RoleDto>()
        .ForMember(m => m.RoleName, c => c.MapFrom(s => s.RoleName));

      CreateMap<RegisterDto, User>();
      CreateMap<LoginDto, User>()
        .ForMember(m => m.Login, c => c.MapFrom(s => s.Login))
        .ForMember(m => m.Password, c => c.MapFrom(s => s.Password));
      CreateMap<CreateRoleDto, Role>();
      CreateMap<CreateCategoryFurnitureDto, CategoryFurniture>();
      CreateMap<CreateCategoryMaterialDto, CategoryMaterial>();
      CreateMap<CreateClientDto, Client>();
      CreateMap<CreateEmployeeDto, Employee>();
      CreateMap<CreateFurnitureDto, Furniture>();
      CreateMap<CreateFurnitureMaterialDto, FurnitureMaterial>();
      CreateMap<CreateMaterialDto, Material>();
      CreateMap<CreateOrderDto, Order>();
      CreateMap<CreateStatusOrderDto, StatusOrder>();
      CreateMap<UpdateCategoryFurnitureDto, CategoryFurniture>();
      CreateMap<UpdateCategoryMaterialDto, CategoryMaterial>();
      CreateMap<UpdateClientDto, Client>();
      CreateMap<UpdateEmployeeDto, Employee>();
      CreateMap<UpdateFurnitureDto, Furniture>();
      CreateMap<UpdateFurnitureMaterialDto, FurnitureMaterial>();
      CreateMap<UpdateMaterialDto, Material>();
      CreateMap<UpdateOrderDto, Order>();
      CreateMap<UpdateRoleDto, Role>();
      CreateMap<UpdateStatusOrderDto, StatusOrder>();
      CreateMap<UpdateUserDto, User>();
    }
  }
}