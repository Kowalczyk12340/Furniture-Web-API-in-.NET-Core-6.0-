using AutoMapper;
using FurnitureAPI.Data;
using FurnitureAPI.Dtos;
using FurnitureAPI.Dtos.Create;
using FurnitureAPI.Dtos.Update;
using FurnitureAPI.Exceptions;
using FurnitureAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace FurnitureAPI.Services.Interfaces
{
  public class FurnitureService : IFurnitureService
  {
    private readonly FurnitureDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<FurnitureService> _logger;

    public FurnitureService(FurnitureDbContext dbContext, IMapper mapper, ILogger<FurnitureService> logger)
    {
      _dbContext = dbContext;
      _mapper = mapper;
      _logger = logger;
    }

    public async Task<int> Create(CreateFurnitureDto dto)
    {
      _logger.LogInformation("Creating a new furniture in this database");
      var furniture = _mapper.Map<Furniture>(dto);
      await _dbContext.Furnitures.AddAsync(furniture);
      await _dbContext.SaveChangesAsync();
      return furniture.IdFurniture;
    }

    public async Task Delete(int id)
    {
      _logger.LogWarning($"Furniture with id: {id} DELETE action invoked");

      var furniture = await _dbContext
        .Furnitures
        .Include(x => x.Order)
        .Include(x => x.CategoryFurniture)
        .FirstOrDefaultAsync(x => x.IdFurniture == id);

      if(furniture == null)
      {
        throw new NotFoundException("Furniture is not found");
      }

      _dbContext.Furnitures.Remove(furniture);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<FurnitureDto>> GetAll()
    {
      _logger.LogInformation("Getting all the material avilable in this database");
      var furnitures = await _dbContext
        .Furnitures
        .Include(x => x.Order)
        .Include(x => x.CategoryFurniture)
        .ToListAsync();

      var furnitureDtos = _mapper.Map<List<FurnitureDto>>(furnitures);
      return furnitureDtos;
    }

    public async Task<FurnitureDto> GetById(int id)
    {
      _logger.LogInformation($"Getting the furniture by {id}");
      var furniture = await _dbContext
        .Furnitures
        .Include(x => x.Order)
        .Include(x => x.CategoryFurniture)
        .FirstOrDefaultAsync(x => x.IdFurniture == id);

      if (furniture == null)
      {
        throw new NotFoundException("Furniture is not found");
      }

      var result = _mapper.Map<FurnitureDto>(furniture);
      return result;
    }

    public string SaveToCsv(IEnumerable<FurnitureDto> components)
    {
      var headers = "IdFurniture;IdOrder;IdCategoryFurniture;FurnitureName;FurniturePrice;FurnitureUnit;FurnitureWidth;FurnitureHeight;FurnitureDepth;FurnitureDescription;";

      var csv = new StringBuilder(headers);

      csv.Append(Environment.NewLine);

      foreach(var component in components)
      {
        csv.Append(component.GetExportObject());
        csv.Append(Environment.NewLine);
      }
      csv.Append($"Count: {components.Count()}");
      csv.Append(Environment.NewLine);

      return csv.ToString();
    }

    public async Task Update(long id, UpdateFurnitureDto dto)
    {
      _logger.LogInformation($"Updating the Furniture by {id}");
      var furniture = await _dbContext
        .Furnitures
        .Include(x => x.Order)
        .Include(x => x.CategoryFurniture)
        .FirstOrDefaultAsync(x => x.IdFurniture == id);

      if (furniture is null)
      {
        throw new NotFoundException("Furniture is not found");
      }

      furniture.FurnitureName = dto.FurnitureName;
      furniture.FurniturePrice = dto.FurniturePrice;
      furniture.FurnitureUnit = dto.FurnitureUnit;
      furniture.FurnitureWidth = dto.FurnitureWidth;
      furniture.FurnitureHeight = dto.FurnitureHeight;
      furniture.FurnitureDepth = dto.FurnitureDepth;
      furniture.FurnitureDescription = dto.FurnitureDescription;
    }
  }
}
