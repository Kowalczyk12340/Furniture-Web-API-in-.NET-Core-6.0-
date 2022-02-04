﻿namespace FurnitureAPI.Validators
{
  public enum SortDirection
  {
    ASC,
    DESC
  }
  public class FurnitureQuery
  {
    public string SearchPhrase { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SortBy { get; set; }
    public SortDirection SortDirection { get; set; }
  }
}