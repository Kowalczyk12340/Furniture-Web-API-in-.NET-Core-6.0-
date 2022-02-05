using AutoMapper;
using FurnitureAPI.Data;
using FurnitureAPI.Dtos;
using FurnitureAPI.Dtos.Create;
using FurnitureAPI.Dtos.Update;

namespace FurnitureAPI.Services.Interfaces
{
  public class OrderStatusService : IOrderStatusService
  {
    private readonly FurnitureDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<OrderStatusService> _logger;

    public OrderStatusService(FurnitureDbContext dbContext, IMapper mapper, ILogger<OrderStatusService> logger)
    {
      _dbContext = dbContext;
      _mapper = mapper;
      _logger = logger;
    }

    public async Task<int> Create(CreateStatusOrderDto dto)
    {
      throw new NotImplementedException();
    }

    public async Task Delete(int id)
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<StatusOrderDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public async Task<StatusOrderDto> GetById(int id)
    {
      throw new NotImplementedException();
    }

    public string SaveToCsv(IEnumerable<StatusOrderDto> components)
    {
      throw new NotImplementedException();
    }

    public async Task Update(long id, UpdateStatusOrderDto dto)
    {
      throw new NotImplementedException();
    }
  }
}
