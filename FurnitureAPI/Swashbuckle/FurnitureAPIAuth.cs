using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FurnitureAPI.Swashbuckle
{
  public class FurnitureAPIAuth : Attribute, IAsyncActionFilter
  {
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
      var identity = context.HttpContext.User.Identities.FirstOrDefault(x => x.AuthenticationType == "Token");

      if (identity is null)
      {
        context.Result = new UnauthorizedResult();
        return;
      }
      await next();
    }
  }
}
