using AutoMapper;
using FurnitureAPI.Data;
using FurnitureAPI.Dtos;
using FurnitureAPI.Dtos.Create;
using FurnitureAPI.Dtos.Update;

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
      throw new NotImplementedException();
    }

    public async Task Delete(int id)
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<FurnitureDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public async Task<FurnitureDto> GetById(int id)
    {
      throw new NotImplementedException();
    }

    public string SaveToCsv(IEnumerable<FurnitureDto> components)
    {
      throw new NotImplementedException();
    }

    public async Task Update(long id, UpdateFurnitureDto dto)
    {
      throw new NotImplementedException();
    }
  }
}
