using AutoMapper;
using FurnitureAPI.Data;
using FurnitureAPI.Dtos;
using FurnitureAPI.Dtos.Create;
using FurnitureAPI.Dtos.Update;

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
      throw new NotImplementedException();
    }

    public async Task Delete(int id)
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<CategoryFurnitureDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public async Task<CategoryFurnitureDto> GetById(int id)
    {
      throw new NotImplementedException();
    }

    public string SaveToCsv(IEnumerable<CategoryFurnitureDto> components)
    {
      throw new NotImplementedException();
    }

    public async Task Update(long id, UpdateCategoryFurnitureDto dto)
    {
      throw new NotImplementedException();
    }
  }
}
