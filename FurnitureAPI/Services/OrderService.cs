using AutoMapper;
using FurnitureAPI.Data;
using FurnitureAPI.Dtos;
using FurnitureAPI.Dtos.Create;
using FurnitureAPI.Dtos.Update;

namespace FurnitureAPI.Services.Interfaces
{
  public class OrderService : IOrderService
  {
    private readonly FurnitureDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<OrderService> _logger;

    public OrderService(FurnitureDbContext dbContext, IMapper mapper, ILogger<OrderService> logger)
    {
      _dbContext = dbContext;
      _mapper = mapper;
      _logger = logger;
    }
    public async Task<int> Create(CreateOrderDto dto)
    {
      throw new NotImplementedException();
    }

    public async Task Delete(int id)
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<OrderDto>> GetAll()
    {
      throw new NotImplementedException();
    }

    public async Task<OrderDto> GetById(int id)
    {
      throw new NotImplementedException();
    }

    public string SaveToCsv(IEnumerable<OrderDto> components)
    {
      throw new NotImplementedException();
    }

    public async Task Update(long id, UpdateOrderDto dto)
    {
      throw new NotImplementedException();
    }
  }
}
