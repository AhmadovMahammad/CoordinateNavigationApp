using CommunityToolkit.Mvvm.ComponentModel;
using CoordinateNavigation.Constants.Enums;
using CoordinateNavigation.MVVM.Models;
using CoordinateNavigation.Services.Interfaces;

namespace CoordinateNavigation.MVVM.ViewModels
{
    public abstract class BaseCoordinateViewModel : ObservableObject
    {
        protected readonly ICoordinateService _coordinateService;

        protected BaseCoordinateViewModel(ICoordinateService coordinateService)
        {
            _coordinateService = coordinateService;
            Latitude = InitializeCoordinate(fromLatitude: true);
            Longitude = InitializeCoordinate(fromLatitude: false);
        }

        public Coordinate Latitude { get; protected set; }
        public Coordinate Longitude { get; protected set; }

        public IReadOnlyList<EarthDirection> LatitudeDirections => new[] { EarthDirection.North, EarthDirection.South };
        public IReadOnlyList<EarthDirection> LongitudeDirections => new[] { EarthDirection.East, EarthDirection.West };

        public abstract bool IsDms { get; }

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

        protected string FormatComposite(Coordinate coordinate, bool isDms)
        {
            return isDms
                ? $"{coordinate.EarthDirection} {coordinate.Degrees}° {coordinate.Minutes}' {coordinate.Seconds}\""
                : $"{coordinate.EarthDirection} {coordinate.Degrees}°";
        }

        private Coordinate InitializeCoordinate(bool fromLatitude)
        {
            return new Coordinate(fromLatitude)
            {
                EarthDirection = fromLatitude ? EarthDirection.North : EarthDirection.East,
                FromDms = IsDms
            };
        }
    }
}
