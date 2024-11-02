using CoordinateNavigation.Constants.Enums;
using CoordinateNavigation.MVVM.Models;
using CoordinateNavigation.Services.Interfaces;

namespace CoordinateNavigation.MVVM.ViewModels
{
    public class DecimalCoordinateViewModel : BaseCoordinateViewModel
    {
        public DecimalCoordinateViewModel(IEventAggregator eventAggregator, ICoordinateService coordinateService)
            : base(eventAggregator, coordinateService)
        {

        }

        protected override CoordinateFormat CordFormat => CoordinateFormat.DD;

        public override void ConvertFromOpposite(Coordinate lat, Coordinate lon)
        {
            Latitude = _coordinateService.GetDecimalDegrees(lat);
            Longitude = _coordinateService.GetDecimalDegrees(lon);

            OnPropertyChanged(nameof(Latitude));
            OnPropertyChanged(nameof(Longitude));
        }

        public override string GetCoordinateComposite()
        {
            return $"Latitude: {FormatComposite(Latitude, CordFormat)}\nLongitude: {FormatComposite(Longitude, CordFormat)}";
        }
    }
}
