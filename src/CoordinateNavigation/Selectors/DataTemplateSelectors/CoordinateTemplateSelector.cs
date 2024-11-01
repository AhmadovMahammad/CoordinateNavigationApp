using System.Windows;
using System.Windows.Controls;

namespace CoordinateNavigation.Selectors.DataTemplateSelectors
{
    public class CoordinateTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is bool isDmsCoordinate)
            {
                return isDmsCoordinate switch
                {
                    true => Dms2DdTemplate,
                    false => Dd2DmsTemplate,
                };
            }

            return base.SelectTemplate(item, container);
        }

        public DataTemplate Dd2DmsTemplate { get; set; } = null!;
        public DataTemplate Dms2DdTemplate { get; set; } = null!;
    }
}
