using CoordinateNavigation.MVVM.Models;

namespace CoordinateNavigation.Services.Interfaces
{
    public interface ICoordinateService
    {
        Coordinate GetDms(Coordinate dd);
        Coordinate GetDecimalDegrees(Coordinate dms);
    }
}
