using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Input;

namespace CoordinateNavigation.Helpers.Extensions
{
    public class RelayKeyBinding : KeyBinding
    {
        public static readonly DependencyProperty CommandBindingProperty = DependencyProperty.Register(
            nameof(CommandBinding), typeof(RelayCommand), typeof(RelayKeyBinding),
            new FrameworkPropertyMetadata(OnCommandBindingChanged));

        public RelayCommand CommandBinding
        {
            get => (RelayCommand)GetValue(CommandBindingProperty);
            set => SetValue(CommandBindingProperty, value);
        }

        private static void OnCommandBindingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var keyBinding = (RelayKeyBinding)d;
            keyBinding.Command = (RelayCommand)e.NewValue;
        }
    }
}
