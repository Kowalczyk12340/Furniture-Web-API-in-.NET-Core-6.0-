using FluentValidation;
using FurnitureAPI.Data;
using FurnitureAPI.Models;

namespace FurnitureAPI.Validators
{
  public class FurnitureQueryValidator : AbstractValidator<FurnitureQuery>
  {
    private int[] allowedPageSizes = new[] { 5, 10, 15 };

    private string[] allowedSortByColumnNames =
      {nameof(Furniture.FurnitureName), nameof(Furniture.CategoryFurniture), nameof(Furniture.FurnitureDescription),};

    public FurnitureQueryValidator()
    {
      RuleFor(r => r.PageNumber).GreaterThanOrEqualTo(1);
      RuleFor(r => r.PageSize).Custom((value, context) =>
      { 
        if(!allowedPageSizes.Contains(value))
        {
          context.AddFailure("PageSize", $"PageSize must in [{string.Join(",", allowedPageSizes)}]");
        }
      });

      RuleFor(r => r.SortBy)
        .Must(value => string.IsNullOrEmpty(value) || allowedSortByColumnNames.Contains(value))
                .WithMessage($"Sort by is optional, or must be in [{string.Join(",", allowedSortByColumnNames)}]");
    }
  }
}