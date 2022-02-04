using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureAPI.Models
{
  public abstract class DomainEntity
  {
    [NotMapped]
    private readonly List<INotification> _events = new List<INotification>();

    [NotMapped]
    public IEnumerable<INotification> Events => _events.AsReadOnly();

    public void AddEvent(INotification @event)
    {
      _events.Add(@event);
    }

    public void ClearEvents()
    {
      _events.Clear();
    }
  }
}