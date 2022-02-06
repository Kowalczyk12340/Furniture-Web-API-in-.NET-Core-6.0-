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
  public class EmployeeService : IEmployeeService
  {
    private readonly FurnitureDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<EmployeeService> _logger;

    public EmployeeService(FurnitureDbContext dbContext, IMapper mapper, ILogger<EmployeeService> logger)
    {
      _dbContext = dbContext;
      _mapper = mapper;
      _logger = logger;
    }

    public async Task<int> Create(CreateEmployeeDto dto)
    {
      _logger.LogInformation("Creating a new employee");
      var employee = _mapper.Map<Employee>(dto);
      await _dbContext.Employees.AddAsync(employee);
      await _dbContext.SaveChangesAsync();
      return employee.EmployeeId;
    }

    public async Task Delete(int id)
    {
      _logger.LogWarning($"It will be deleted employee with {id}");
      var employee = await _dbContext
        .Employees
        .FirstOrDefaultAsync(x => x.EmployeeId == id);

      if(employee is null)
      {
        throw new NotFoundException("Employee is not found");
      }

      _dbContext.Employees.Remove(employee);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<EmployeeDto>> GetAll()
    {
      _logger.LogInformation("Display all the employees");

      var employees = await _dbContext
        .Employees
        .ToListAsync();

      var employeeDtos = _mapper.Map<List<EmployeeDto>>(employees);
      return employeeDtos;
    }

    public async Task<EmployeeDto> GetById(int id)
    {
      _logger.LogInformation($"Display employee with chosen {id}");

      var employee = await _dbContext
        .Employees
        .FirstOrDefaultAsync(x => x.EmployeeId == id);

      if(employee is null)
      {
        throw new NotFoundException("Employee is not found");
      }

      var result = _mapper.Map<EmployeeDto>(employee);
      return result;
    }

    public string SaveToCsv(IEnumerable<EmployeeDto> components)
    {
      var headers = "EmployeeId;EmployeeName;EmployeeSurname;EmployeeIsDelivered;EmployeeNumberHome;EmployeeEmail;EmployeeSeniority";

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

    public async Task Update(long id, UpdateEmployeeDto dto)
    {
      _logger.LogInformation($"Edit employee with {id}");
      var employee = await _dbContext
        .Employees
        .FirstOrDefaultAsync(x => x.EmployeeId == id);

      if(employee is null)
      {
        throw new NotFoundException("Employee is not found");
      }
      employee.EmployeeName = dto.EmployeeName;
      employee.EmployeeSurname = dto.EmployeeSurname;
      employee.EmployeeIsDelivered = dto.EmployeeIsDelivered;
      employee.EmployeeNumberHome = dto.EmployeeNumberHome;
      employee.EmployeeEmail = dto.EmployeeEmail;
      employee.EmployeeSeniority = dto.EmployeeSeniority;

      await _dbContext.SaveChangesAsync();
    }
  }
}