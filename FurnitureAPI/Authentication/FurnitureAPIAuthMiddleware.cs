using FurnitureAPI.Data;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore;

namespace FurnitureAPI.Authentication
{
  public class FurnitureAPIAuthMiddleware
  {
    private readonly RequestDelegate _next;

    public FurnitureAPIAuthMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
      var furnitureContext = context.RequestServices.GetRequiredService<FurnitureDbContext>();

      if (context.Request.Headers.TryGetValue("Authorization", out var furnitureAuthorizationHeader))
      {
        var values = furnitureAuthorizationHeader.FirstOrDefault()?.Split();
        if (!(values is null) && values.Count() == 2)
        {
          var authorizationType = values[0];
          var tokenValue = values[1];
          if (authorizationType == "Token" && Guid.TryParse(tokenValue, out var token))
          {
            var user = await furnitureContext.AuthTokens.FirstOrDefaultAsync(x => x.Id == token);
            if (!(user is null))
            {
              context.User.AddIdentity(new GenericIdentity(user.Name, "Token"));
            }
          }
        }
      }
      await _next.Invoke(context);
    }
  }
}