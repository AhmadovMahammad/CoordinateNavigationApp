using CoordinateNavigation.Events.Common;
using CoordinateNavigation.MVVM.Models;

namespace CoordinateNavigation.Events
{
    public record CoordinateChangedEvent : IEvent
    {
        public CoordinateChangedEvent(Coordinate coordinate, bool isLatitude)
        {
            Coordinate = coordinate;
            IsLatitude = isLatitude;
        }

        public Coordinate Coordinate { get; init; }
        public bool IsLatitude { get; init; }
    }
}
