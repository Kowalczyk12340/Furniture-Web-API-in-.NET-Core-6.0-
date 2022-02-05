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
      _logger.LogInformation("Create a new order");
      var order = _mapper.Map<Order>(dto);
      await _dbContext.Orders.AddAsync(order);
      await _dbContext.SaveChangesAsync();
      return order.IdOrder;
    }

    public async Task Delete(int id)
    {
      _logger.LogWarning($"It will be deleted order with id: {id}");

      var order = await _dbContext
        .Orders
        .Include(x => x.Client)
        .Include(x => x.Employee)
        .Include(x => x.StatusOrder)
        .FirstOrDefaultAsync(x => x.IdOrder == id);

      if(order is null)
      {
        throw new NotFoundException("Order is not found");
      }

      _dbContext.Orders.Remove(order);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<OrderDto>> GetAll()
    {
      _logger.LogInformation("Displaying all the orders");
      var orders = await _dbContext
        .Orders
        .Include(x => x.Client)
        .Include(x => x.Employee)
        .Include(x => x.StatusOrder)
        .ToListAsync();

      var orderDtos = _mapper.Map<List<OrderDto>>(orders);
      return orderDtos;
    }

    public async Task<OrderDto> GetById(int id)
    {
      _logger.LogInformation($"Editing order with {id}");
      var order = await _dbContext
        .Orders
        .Include(x => x.Client)
        .Include(x => x.Employee)
        .Include(x => x.StatusOrder)
        .FirstOrDefaultAsync(x => x.IdOrder == id);

      if(order is null)
      {
        throw new NotFoundException("Order is not found");
      }

      var result = _mapper.Map<OrderDto>(order);
      return result;
    }

    public string SaveToCsv(IEnumerable<OrderDto> components)
    {
      _logger.LogInformation($"Save to csv file");
      var headers = "IdOrder;IdClient;IdEmployee;IdStatusOrder;OrderCode;OrderDateSubmission;OrderDateRealization;OrderDeadlineRealization;OrderPrePayment;OrderPayment;OrderInfo;";
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
  
    public async Task Update(long id, UpdateOrderDto dto)
    {
      _logger.LogInformation($"Edit order with {id}");
      var order = await _dbContext
        .Orders
        .Include(x => x.Client)
        .Include(x => x.Employee)
        .Include(x => x.StatusOrder)
        .FirstOrDefaultAsync(x => x.IdOrder == id);

      if(order is null)
      {
        throw new NotFoundException("Order is not found");
      }

      order.OrderCode = dto.OrderCode;
      order.OrderDateSubmission = dto.OrderDateSubmission;
      order.OrderDateRealization = dto.OrderDateRealization;
      order.OrderDeadlineRealization = dto.OrderDeadlineRealization;
      order.OrderInfo = dto.OrderInfo;
      order.OrderPayment = dto.OrderPayment;
      order.OrderPrePayment = dto.OrderPrePayment;
    }
  }
}
