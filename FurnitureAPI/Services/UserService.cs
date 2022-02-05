using AutoMapper;
using FurnitureAPI.Authentication;
using FurnitureAPI.Data;
using FurnitureAPI.Dtos;
using FurnitureAPI.Dtos.Update;
using FurnitureAPI.Exceptions;
using FurnitureAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FurnitureAPI.Services.Interfaces
{
  public class UserService : IUserService
  {
    private readonly FurnitureDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<UserService> _logger;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly AuthenticationSettings _authenticationSettings;

    public UserService(FurnitureDbContext dbContext, IMapper mapper, ILogger<UserService> logger,
      IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
    {
      _dbContext = dbContext;
      _mapper = mapper;
      _logger = logger;
      _passwordHasher = passwordHasher;
      _authenticationSettings = authenticationSettings;
    }

    public async Task Delete(int id)
    {
      _logger.LogWarning($"It will be deleted user with id: {id}");

      var user = await _dbContext
        .Users
        .Include(u => u.Role)
        .FirstOrDefaultAsync(x => x.IdUser == id);

      if(user is null)
      {
        throw new NotFoundException("User is not found");
      }

      _dbContext.Users.Remove(user);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<string> GenerateJwt(LoginDto dto)
    {
      var user = await _dbContext
        .Users
        .Include(u => u.Role)
        .FirstOrDefaultAsync(x => x.Login == dto.Login);

      if (user is null)
      {
        throw new BadRequestException("Invalid username or password");
      }

      var result = _passwordHasher.VerifyHashedPassword(user, user.Password, dto.Password);

      if (result == PasswordVerificationResult.Failed)
      {
        throw new BadRequestException("Invalid username or password");
      }

      var claims = new List<Claim>()
      {
                new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString()),
                new Claim(ClaimTypes.Name, $"{user.UserFirstName}"),
                new Claim(ClaimTypes.Role, $"{user.Role.RoleName}"),
                new Claim(ClaimTypes.Country, $"{user.Nationality}"),
                new Claim(ClaimTypes.Email, $"{user.Login}"),
                new Claim(ClaimTypes.Surname, $"{user.LastName}"),
                new Claim(ClaimTypes.DateOfBirth, $"{user.DateOfBirth}"),
                new Claim(ClaimTypes.Authentication, $"{user.Password}")
      };

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
      var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
      var expires = DateTime.Now.AddMinutes(_authenticationSettings.JwtExpireMinutes);

      var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
          _authenticationSettings.JwtIssuer,
          claims,
          expires: expires,
          signingCredentials: cred);

      var tokenHandler = new JwtSecurityTokenHandler();
      var finishToken = tokenHandler.WriteToken(token);
      return finishToken;
    }

    public async Task<IEnumerable<UserDto>> GetAll()
    {
      _logger.LogInformation("Display all the users available in the database");
      var users = await _dbContext
        .Users
        .Include(u => u.Role)
        .ToListAsync();

      var userDtos = _mapper.Map<List<UserDto>>(users);
      return userDtos;
    }

    public async Task<UserDto> GetById(int id)
    {
      _logger.LogInformation("Display all the users available in the database");
      var user = await _dbContext
        .Users
        .Include(u => u.Role)
        .FirstOrDefaultAsync(x => x.IdRole == id);

      if(user is null)
      {
        throw new NotFoundException("User is not found");
      }

      var result = _mapper.Map<UserDto>(user);
      return result;
    }

    public async Task RegisterUser(RegisterDto dto)
    {
      var newUser = new User()
      {
        Login = dto.Login,
        DateOfBirth = dto.DateOfBirth,
        UserFirstName = dto.UserFirstName,
        LastName = dto.LastName,
        Nationality = dto.Nationality,
        IdRole = dto.IdRole,
      };

      var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);

      newUser.Password = hashedPassword;

      await _dbContext.Users.AddAsync(newUser);
      await _dbContext.SaveChangesAsync();
    }

    public string SaveToCsv(IEnumerable<UserDto> components)
    {
      var headers = "Id;FirstName;LastName;IsActive;DateOfBirth;Login;Nationality;RoleName";

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

    public async Task Update(int id, UpdateUserDto dto)
    {
      _logger.LogInformation($"Edit user with id: {id}");
      var user = await _dbContext
        .Users
        .Include(u => u.Role)
        .FirstOrDefaultAsync(x => x.IdRole == id);

      if(user is null)
      {
        throw new NotFoundException("User not found");
      }

      user.UserFirstName = dto.UserFirstName;
      user.LastName = dto.LastName;
      user.Login = dto.Login;
      var hashedPassword = _passwordHasher.HashPassword(user, dto.Password);
      user.Password = hashedPassword;
      user.DateOfBirth = dto?.DateOfBirth;
      user.Nationality = dto.Nationality;
      user.IsActive = dto.IsActive;
      await _dbContext.SaveChangesAsync();
    }
  }
}
