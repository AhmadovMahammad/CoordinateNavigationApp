using CoordinateNavigation.Constants.Enums;
using CoordinateNavigation.MVVM.Models;
using CoordinateNavigation.Services.Interfaces;

namespace CoordinateNavigation.MVVM.ViewModels
{
    public class DmsCoordinateViewModel : BaseCoordinateViewModel
    {
        public DmsCoordinateViewModel(IEventAggregator eventAggregator, ICoordinateService coordinateService)
            : base(eventAggregator, coordinateService)
        {

        }

        protected override CoordinateFormat CordFormat => CoordinateFormat.DMS;

        public override void ConvertFromOpposite(Coordinate lat, Coordinate lon)
        {
            Latitude = _coordinateService.GetDms(lat);
            Longitude = _coordinateService.GetDms(lon);

            OnPropertyChanged(nameof(Latitude));
            OnPropertyChanged(nameof(Longitude));
        }

        public override string GetCoordinateComposite()
        {
            return $"Latitude: {FormatComposite(Latitude, CordFormat)}\nLongitude: {FormatComposite(Longitude, CordFormat)}";
        }

        public override void ClearFields()
        {
            base.ClearFields();
            Latitude.Minutes = Longitude.Minutes = 0;
            Latitude.Seconds = Longitude.Seconds = 0;
        }
    }
}
