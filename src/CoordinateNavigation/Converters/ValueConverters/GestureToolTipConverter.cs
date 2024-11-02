using CoordinateNavigation.Constants;
using System.Globalization;
using System.Windows.Data;

namespace CoordinateNavigation.Converters.ValueConverters
{
    public class GestureTooltipConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string param = parameter?.ToString() ?? string.Empty;

            return param switch
            {
                "ConvertCoordinate" => $"Convert coordinates using {GestureBindings.ConvertCoordinateGesture.Modifiers} + {GestureBindings.ConvertCoordinateGesture.Key}",
                "ToggleCoordinateType" => $"Change coordinate type with {GestureBindings.ToggleCoordinateTypeGesture.Modifiers} + {GestureBindings.ToggleCoordinateTypeGesture.Key}",
                "CopyCoordinate" => $"Copy coordinate using {GestureBindings.CopyGesture.Modifiers} + {GestureBindings.CopyGesture.Key}",
                "ClearFields" => $"Clear fields with {GestureBindings.ClearGesture.Modifiers} + {GestureBindings.ClearGesture.Key}",
                "ViewInMap" => $"View coordinates on map using {GestureBindings.ViewInMapGesture.Modifiers} + {GestureBindings.ViewInMapGesture.Key}",
                "ToggleAutoConversion" => $"Toggle auto conversion using {GestureBindings.ToggleAutoConversionGesture.Modifiers} + {GestureBindings.ToggleAutoConversionGesture.Key}",
                _ => "Unknown command"
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
