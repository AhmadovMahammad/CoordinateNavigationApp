using CoordinateNavigation.Constants.Enums;
using CoordinateNavigation.MVVM.Models;
using CoordinateNavigation.Services.Interfaces;
using System.Net;

namespace CoordinateNavigation.Services.Implementations
{
    public class CoordinateService : ICoordinateService
    {
        public Coordinate GetDecimalDegrees(Coordinate dms)
        {
            //Example: Convert DMS: 51° 30' 35.5140" to Decimal Degrees
            //DD = d + (m / 60) + (s / 3600) = 51.509865

            double degrees = dms.Degrees + (dms.Minutes / 60) + (dms.Seconds / 3600);

            Coordinate coordinate = new Coordinate(dms.FromLatitude)
            {
                CordFormat = CoordinateFormat.DD,
                Degrees = dms.Sign * degrees,
            };

            return coordinate;
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
                CordFormat = CoordinateFormat.DMS,
                Degrees = degrees,
                Minutes = minutes,
                Seconds = seconds,
            };

            if (dd.FromLatitude) coordinate.EarthDirection = dd.Degrees >= 0 ? EarthDirection.North : EarthDirection.South;
            else coordinate.EarthDirection = dd.Degrees >= 0 ? EarthDirection.East : EarthDirection.West;

            return coordinate;
        }
    }
}
