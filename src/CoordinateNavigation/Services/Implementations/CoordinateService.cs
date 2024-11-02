using CoordinateNavigation.Constants.Enums;
using CoordinateNavigation.MVVM.Models;
using CoordinateNavigation.Services.Interfaces;

namespace CoordinateNavigation.Services.Implementations
{
    public class CoordinateService : ICoordinateService
    {
        public Coordinate GetDecimalDegrees(Coordinate dms)
        {
            //Example: Convert DMS: 51° 30' 35.5140" to Decimal Degrees
            //DD = d + (m / 60) + (s / 3600) = 51.509865

            int sign = (dms.FromLatitude
                ? (dms.EarthDirection == EarthDirection.North ? 1 : -1)
                : (dms.EarthDirection == EarthDirection.East ? 1 : -1));

            double degrees = dms.Degrees + (dms.Minutes / 60) + (dms.Seconds / 3600);

            return new Coordinate(dms.FromLatitude)
            {
                Degrees = sign * degrees,
                FromDms = !dms.FromDms,
            };
        }

        public Coordinate GetDms(Coordinate dd)
        {
            //Example: Convert Latitude: 51.509865 to Degrees, Minutes, Seconds (DMS)
            //d = integer(51.509865) = 51
            //m = integer((dd – d) × 60) = 30
            //s = (dd – d – m / 60) × 3600 = 35.5140

            double decimalDegrees = Math.Abs(dd.Degrees);

            double degrees = (int)decimalDegrees;
            double minutes = (int)((decimalDegrees - degrees) * 60);
            double seconds = (decimalDegrees - degrees - (minutes / 60)) * 3600;

            var coordinate = new Coordinate(dd.FromLatitude)
            {
                Degrees = degrees,
                Minutes = minutes,
                Seconds = seconds,
                FromDms = !dd.FromDms,
            };

            if (dd.FromLatitude) coordinate.EarthDirection = dd.Degrees >= 0 ? EarthDirection.North : EarthDirection.South;
            else coordinate.EarthDirection = dd.Degrees >= 0 ? EarthDirection.East : EarthDirection.West;

            return coordinate;
        }
    }
}
