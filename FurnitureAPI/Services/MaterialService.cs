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
  public class MaterialService : IMaterialService
  {
    private readonly FurnitureDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<MaterialService> _logger;

    public MaterialService(FurnitureDbContext dbContext, IMapper mapper, ILogger<MaterialService> logger)
    {
      _dbContext = dbContext;
      _mapper = mapper;
      _logger = logger;
    }

    public async Task<int> Create(CreateMaterialDto dto)
    {
      _logger.LogInformation("Creating a new material");
      var material = _mapper.Map<Material>(dto);
      await _dbContext.Materials.AddAsync(material);
      await _dbContext.SaveChangesAsync();
      return material.MaterialId;
    }

    public async Task Delete(int id)
    {
      _logger.LogWarning($"It will be deleted material with {id}");
      var material = await _dbContext
        .Materials
        .Include(x => x.CategoryMaterial)
        .FirstOrDefaultAsync(x => x.MaterialId == id);

      if(material is null)
      {
        throw new NotFoundException("Material is not found");
      }

      _dbContext.Materials.Remove(material);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<MaterialDto>> GetAll()
    {
      _logger.LogInformation("Display all the materials");

      var materials = await _dbContext
        .Materials
        .Include(x => x.CategoryMaterial)
        .ToListAsync();

      var materialDtos = _mapper.Map<List<MaterialDto>>(materials);
      return materialDtos;
    }

    public async Task<MaterialDto> GetById(int id)
    {
      _logger.LogInformation($"Display material with chosen {id}");

      var material = await _dbContext
        .Materials
        .Include(x => x.CategoryMaterial)
        .FirstOrDefaultAsync(x => x.MaterialId == id);

      if(material is null)
      {
        throw new NotFoundException("Material is not found");
      }

      var result = _mapper.Map<MaterialDto>(material);
      return result;
    }

    public string SaveToCsv(IEnumerable<MaterialDto> components)
    {
      var headers = "MaterialId;IdCategoryMaterial;MaterialName;MaterialPrice;MaterialUnit;MaterialStockStatus;MaterialDescription;";

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

    public async Task Update(long id, UpdateMaterialDto dto)
    {
      _logger.LogInformation($"Edit material with {id}");
      var material = await _dbContext
        .Materials
        .Include(x => x.CategoryMaterial)
        .FirstOrDefaultAsync(x => x.MaterialId == id);

      if(material is null)
      {
        throw new NotFoundException("Material is not found");
      }

      material.MaterialDescription = dto.MaterialDescription;
      material.MaterialName = dto.MaterialName;
      material.MaterialPrice = dto.MaterialPrice;
      material.MaterialStockStatus = dto.MaterialStockStatus;
      material.MaterialUnit = dto.MaterialUnit;
    }
  }
}
