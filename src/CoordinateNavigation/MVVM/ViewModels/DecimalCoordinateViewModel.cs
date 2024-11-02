using CoordinateNavigation.MVVM.Models;
using CoordinateNavigation.Services.Interfaces;

namespace CoordinateNavigation.MVVM.ViewModels
{
    public class DecimalCoordinateViewModel : BaseCoordinateViewModel
    {
        public DecimalCoordinateViewModel(ICoordinateService coordinateService)
            : base(coordinateService)
        {

        }

        public override bool IsDms => false;

        public override void ConvertFromOpposite(Coordinate lat, Coordinate lon)
        {
            throw new NotSupportedException("Conversion from DMS to Decimal not yet implemented.");
        }

        public override string GetCoordinateComposite()
        {
            return $"Latitude: {FormatComposite(Latitude, isDms: false)}\nLongitude: {FormatComposite(Longitude, isDms: false)}";
        }
    }
}
