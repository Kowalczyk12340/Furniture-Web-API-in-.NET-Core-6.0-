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
  public class CategoryFurnitureService : ICategoryFurnitureService
  {
    private readonly FurnitureDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<CategoryFurnitureService> _logger;

    public CategoryFurnitureService(FurnitureDbContext dbContext, IMapper mapper, ILogger<CategoryFurnitureService> logger)
    {
      _dbContext = dbContext;
      _mapper = mapper;
      _logger = logger;
    }

    public async Task<int> Create(CreateCategoryFurnitureDto dto)
    {
      _logger.LogInformation("Creating a new category furniture");
      var categoryFurniture = _mapper.Map<CategoryFurniture>(dto);
      await _dbContext.CategoryFurnitures.AddAsync(categoryFurniture);
      await _dbContext.SaveChangesAsync();
      return categoryFurniture.CategoryFurnitureId;
    }

    public async Task Delete(int id)
    {
      _logger.LogWarning($"It will be deleted category furniture with {id}");
      var categoryFurniture = await _dbContext
        .CategoryFurnitures
        .FirstOrDefaultAsync(x => x.CategoryFurnitureId == id);

      if(categoryFurniture is null)
      {
        throw new NotFoundException("Category furniture is not found");
      }

      _dbContext.CategoryFurnitures.Remove(categoryFurniture);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<CategoryFurnitureDto>> GetAll()
    {
      _logger.LogInformation($"Display all the category furnitures");

      var categoryFurnitures = await _dbContext
        .CategoryFurnitures
        .ToListAsync();

      var categoryFurnitureDtos = _mapper.Map<List<CategoryFurnitureDto>>(categoryFurnitures);
      return categoryFurnitureDtos;
    }

    public async Task<CategoryFurnitureDto> GetById(int id)
    {
      _logger.LogInformation($"Display category furniture with chosen {id}");

      var categoryFurniture = await _dbContext
        .CategoryFurnitures
        .FirstOrDefaultAsync(x => x.CategoryFurnitureId == id);

      var result = _mapper.Map<CategoryFurnitureDto>(categoryFurniture);
      return result;
    }

    public string SaveToCsv(IEnumerable<CategoryFurnitureDto> components)
    {
      var headers = "IdCategoryFurniture;CategoryFurnitureName;CategoryFurnitureDescription";
      
      var csv = new StringBuilder(headers);

      csv.Append(Environment.NewLine);

      foreach (var component in components)
      {
        csv.Append(component.GetExportObject());
        csv.Append(Environment.NewLine);
      }
      csv.Append($"Count: {components.Count()}");
      csv.Append(Environment.NewLine);

      return csv.ToString();
    }

    public async Task Update(long id, UpdateCategoryFurnitureDto dto)
    {
      _logger.LogInformation($"Edit category furniture with {id}");
      var categoryFurniture = await _dbContext
        .CategoryFurnitures
        .FirstOrDefaultAsync(x => x.CategoryFurnitureId == id);

      if(categoryFurniture is null)
      {
        throw new NotFoundException("Category furniture is not found");
      }

      categoryFurniture.CategoryFurnitureName = dto.CategoryFurnitureName;
      categoryFurniture.CategoryFurnitureDescription = dto.CategoryFurnitureDescription;

      await _dbContext.SaveChangesAsync();
    }
  }
}