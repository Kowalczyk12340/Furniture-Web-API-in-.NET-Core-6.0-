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
  public class CategoryMaterialService : ICategoryMaterialService
  {
    private readonly FurnitureDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<CategoryMaterialService> _logger;

    public CategoryMaterialService(FurnitureDbContext dbContext, IMapper mapper, ILogger<CategoryMaterialService> logger)
    {
      _dbContext = dbContext;
      _mapper = mapper;
      _logger = logger;
    }

    public async Task<int> Create(CreateCategoryMaterialDto dto)
    {
      _logger.LogInformation("Creating a new category of material");
      var categoryMaterial = _mapper.Map<CategoryMaterial>(dto);
      await _dbContext.CategoryMaterials.AddAsync(categoryMaterial);
      await _dbContext.SaveChangesAsync();
      return categoryMaterial.CategoryMaterialId;
    }

    public async Task Delete(int id)
    {
      _logger.LogWarning($"It will be deleted category material with {id}");
      var categoryMaterial = await _dbContext
        .CategoryMaterials
        .FirstOrDefaultAsync(x => x.CategoryMaterialId == id);

      if(categoryMaterial is null)
      {
        throw new NotFoundException("Category material is not found");
      }

      _dbContext.CategoryMaterials.Remove(categoryMaterial);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<CategoryMaterialDto>> GetAll()
    {
      _logger.LogInformation("Display all the category materials");

      var categoryMaterials = await _dbContext
        .CategoryMaterials
        .ToListAsync();

      var categoryMaterialDtos = _mapper.Map<List<CategoryMaterialDto>>(categoryMaterials);
      return categoryMaterialDtos;
    }

    public async Task<CategoryMaterialDto> GetById(int id)
    {
      _logger.LogInformation($"Display category material with chosen {id}");

      var categoryMaterial = await _dbContext
        .CategoryMaterials
        .FirstOrDefaultAsync(x => x.CategoryMaterialId == id);

      if(categoryMaterial is null)
      {
        throw new NotFoundException("Category Material is not found");
      }

      var result = _mapper.Map<CategoryMaterialDto>(categoryMaterial);
      return result;
    }

    public string SaveToCsv(IEnumerable<CategoryMaterialDto> components)
    {
      var headers = "CategoryMaterialId;CategoryMaterialName;CategoryMaterialDescription";
      
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

    public async Task Update(long id, UpdateCategoryMaterialDto dto)
    {
      _logger.LogInformation($"Edit category material with {id}");
      
      var categoryMaterial = await _dbContext
        .CategoryMaterials
        .FirstOrDefaultAsync(x => x.CategoryMaterialId == id);

      if(categoryMaterial is null)
      {
        throw new NotFoundException("Category material is not found");
      }

      categoryMaterial.CategoryMaterialName = dto.CategoryMaterialName;
      categoryMaterial.CategoryMaterialDescription = dto.CategoryMaterialDescription;

      await _dbContext.SaveChangesAsync();
    }
  }
}