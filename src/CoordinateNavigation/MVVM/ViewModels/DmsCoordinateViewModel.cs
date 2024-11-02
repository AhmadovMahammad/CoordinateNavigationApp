using CoordinateNavigation.MVVM.Models;
using CoordinateNavigation.Services.Interfaces;

namespace CoordinateNavigation.MVVM.ViewModels
{
    public class DmsCoordinateViewModel : BaseCoordinateViewModel
    {
        public DmsCoordinateViewModel(ICoordinateService coordinateService)
            : base(coordinateService)
        {

        }

        public override bool IsDms => true;

        public override void ConvertFromOpposite(Coordinate lat, Coordinate lon)
        {
            throw new NotSupportedException("Conversion from Decimal to DMS not yet implemented.");
        }

        public override string GetCoordinateComposite()
        {
            return $"Latitude: {FormatComposite(Latitude, isDms: true)}\nLongitude: {FormatComposite(Longitude, isDms: true)}";
        }

        public override void ClearFields()
        {
            base.ClearFields();
            Latitude.Minutes = Longitude.Minutes = 0;
            Latitude.Seconds = Longitude.Seconds = 0;
        }
    }
}
