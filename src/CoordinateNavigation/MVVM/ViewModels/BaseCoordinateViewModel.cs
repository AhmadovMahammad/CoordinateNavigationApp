using CommunityToolkit.Mvvm.ComponentModel;
using CoordinateNavigation.Constants.Enums;
using CoordinateNavigation.Events;
using CoordinateNavigation.MVVM.Models;
using CoordinateNavigation.Services.Interfaces;

namespace CoordinateNavigation.MVVM.ViewModels
{
    public abstract class BaseCoordinateViewModel : ObservableObject
    {
        protected readonly IEventAggregator _eventAggregator;
        protected readonly ICoordinateService _coordinateService;

        protected BaseCoordinateViewModel(IEventAggregator eventAggregator, ICoordinateService coordinateService)
        {
            _eventAggregator = eventAggregator;
            _coordinateService = coordinateService;

            Latitude = InitializeCoordinate(fromLatitude: true);
            Longitude = InitializeCoordinate(fromLatitude: false);

            Latitude.PropertyChanged += (sender, args) => _eventAggregator.Publish(new CoordinateChangedEvent(Latitude));
            Longitude.PropertyChanged += (sender, args) => _eventAggregator.Publish(new CoordinateChangedEvent(Longitude));
        }

        public Coordinate Latitude { get; protected set; }
        public Coordinate Longitude { get; protected set; }

        public static IReadOnlyList<EarthDirection> LatitudeDirections => [EarthDirection.North, EarthDirection.South];
        public static IReadOnlyList<EarthDirection> LongitudeDirections => [EarthDirection.East, EarthDirection.West];

        protected abstract CoordinateFormat CordFormat { get; }

        // Abstract methods for derived classes
        public abstract void ConvertFromOpposite(Coordinate lat, Coordinate lon);
        public abstract string GetCoordinateComposite();

        public virtual void ClearFields()
        {
            Latitude.Degrees = 0;
            Longitude.Degrees = 0;

            Latitude.EarthDirection = EarthDirection.North;
            Longitude.EarthDirection = EarthDirection.East;
        }

        protected string FormatComposite(Coordinate coordinate, CoordinateFormat coordinateFormat)
        {
            return coordinateFormat == CoordinateFormat.DMS
                ? $"{coordinate.EarthDirection} {coordinate.Degrees}° {coordinate.Minutes}' {coordinate.Seconds}\""
                : $"{coordinate.EarthDirection} {coordinate.Degrees}°";
        }

        private Coordinate InitializeCoordinate(bool fromLatitude)
        {
            return new Coordinate(fromLatitude)
            {
                EarthDirection = fromLatitude ? EarthDirection.North : EarthDirection.East,
                CordFormat = CordFormat
            };
        }
    }
}
