using CoordinateNavigation.Events.Common;
using CoordinateNavigation.MVVM.Models;

namespace CoordinateNavigation.Events
{
    public record CoordinateChangedEvent(Coordinate Coordinate) : IEvent
    {

    }
}
