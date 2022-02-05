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
      _logger.LogInformation("Create a new order status");
      var orderStatus = _mapper.Map<StatusOrder>(dto);
      await _dbContext.StatusOrders.AddAsync(orderStatus);
      await _dbContext.SaveChangesAsync();
      return orderStatus.IdStatusOrder;
    }

    public async Task Delete(int id)
    {
      _logger.LogInformation($"It will be deleted order status with id: {id}");

      var orderStatus = await _dbContext
        .StatusOrders
        .FirstOrDefaultAsync(x => x.IdStatusOrder == id);

      if(orderStatus is null)
      {
        throw new NotFoundException("Order Status is not found");
      }

      _dbContext.StatusOrders.Remove(orderStatus);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<StatusOrderDto>> GetAll()
    {
      _logger.LogInformation("Displaying all the status orders");
      var orderStatuses = await _dbContext
        .StatusOrders
        .ToListAsync();

      var orderStatusDtos = _mapper.Map<List<StatusOrderDto>>(orderStatuses);
      return orderStatusDtos;
    }

    public async Task<StatusOrderDto> GetById(int id)
    {
      _logger.LogInformation($"Editing status orders with {id}");
      var orderStatus = await _dbContext
        .StatusOrders
        .FirstOrDefaultAsync(x => x.IdStatusOrder == id);

      if(orderStatus is null)
      {
        throw new NotFoundException("Status Order is not found");
      }

      var result = _mapper.Map<StatusOrderDto>(orderStatus);
      return result;
    }

    public string SaveToCsv(IEnumerable<StatusOrderDto> components)
    {
      var headers = "Id;Name;Description;";
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

    public async Task Update(long id, UpdateStatusOrderDto dto)
    {
      _logger.LogInformation($"Edit order status with {id}");
      var orderStatus = await _dbContext
        .StatusOrders
        .FirstOrDefaultAsync(x => x.IdStatusOrder == id);

      if(orderStatus is null)
      {
        throw new NotFoundException("Order Status is not found");
      }

      orderStatus.StatusOrderName = dto.StatusOrderName;
      orderStatus.StatusOrderDescription = dto.StatusOrderDescription;
      await _dbContext.SaveChangesAsync();
    }
  }
}