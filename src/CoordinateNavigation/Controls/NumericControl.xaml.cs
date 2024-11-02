using System.Windows;
using System.Windows.Controls;

namespace CoordinateNavigation.Controls
{
    public partial class NumericControl : UserControl
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            nameof(Value), typeof(double), typeof(NumericControl), new PropertyMetadata { DefaultValue = (double)20 });

        public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register(
             nameof(IsReadOnly), typeof(bool), typeof(NumericControl));

        public static readonly DependencyProperty StringFormatProperty = DependencyProperty.Register(
            nameof(StringFormat), typeof(string), typeof(NumericControl));

        public NumericControl()
        {
            InitializeComponent();
        }

        public double Value
        {
            get => (double)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public bool IsReadOnly
        {
            get => (bool)GetValue(IsReadOnlyProperty);
            set => SetValue(IsReadOnlyProperty, value);
        }

        public string StringFormat
        {
            get => (string)GetValue(StringFormatProperty);
            set => SetValue(StringFormatProperty, value);
        }
    }
}
