using Microsoft.AspNetCore.Authorization;

namespace FurnitureAPI.Authentication
{
  public class MinimumAgeRequirement : IAuthorizationRequirement
  {
    public int MinimumAge { get; }

    public MinimumAgeRequirement(int minimumAge)
    {
      MinimumAge = minimumAge;
    }
  }
}