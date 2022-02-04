using FurnitureAPI.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace FurnitureAPI.Authentication.RequirementsModels
{
  public class FurnitureResourceOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, Furniture>
  {
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement, Furniture club)
    {
      if (requirement.ResourceOperation == ResourceOperation.Read ||
          requirement.ResourceOperation == ResourceOperation.Create)
      {
        context.Succeed(requirement);
      }

      var userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;

      return Task.CompletedTask;
    }
  }
}