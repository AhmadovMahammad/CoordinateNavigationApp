using FontAwesome.WPF;
using System.Globalization;
using System.Windows.Data;

namespace CoordinateNavigation.Converters.ValueConverters
{
    public class AutoConversionIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isActiveAutoConversion)
            {
                return isActiveAutoConversion switch
                {
                    true => FontAwesomeIcon.ToggleOff,
                    false => FontAwesomeIcon.ToggleOn,
                };
            }

            return FontAwesomeIcon.None;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
