using AutoMapper;
using FurnitureAPI.Data;
using FurnitureAPI.Dtos;
using FurnitureAPI.Dtos.Create;
using FurnitureAPI.Dtos.Update;

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
      throw new NotImplementedException();
    }

    public async Task Delete(int id)
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<CategoryMaterialDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public async Task<CategoryMaterialDto> GetById(int id)
    {
      throw new NotImplementedException();
    }

    public string SaveToCsv(IEnumerable<CategoryMaterialDto> components)
    {
      throw new NotImplementedException();
    }

    public async Task Update(long id, UpdateCategoryMaterialDto dto)
    {
      throw new NotImplementedException();
    }
  }
}
