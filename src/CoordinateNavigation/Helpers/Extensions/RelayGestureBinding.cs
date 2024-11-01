using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Input;

namespace CoordinateNavigation.Helpers.Extensions
{
    public class RelayGestureBinding : KeyBinding
    {
        // dependency properties
        public static readonly DependencyProperty CommandBindingProperty = DependencyProperty.Register(
            nameof(CommandBinding), typeof(RelayCommand), typeof(RelayGestureBinding),
            new PropertyMetadata(null, OnCommandBindingChanged));

        public static readonly DependencyProperty GestureBindingProperty = DependencyProperty.Register(
            nameof(GestureBinding), typeof(KeyGesture), typeof(RelayGestureBinding),
            new PropertyMetadata(null, OnGestureBindingChanged));


        // bindings
        public RelayCommand CommandBinding
        {
            get => (RelayCommand)GetValue(CommandBindingProperty);
            set => SetValue(CommandBindingProperty, value);
        }

        public KeyGesture GestureBinding
        {
            get => (KeyGesture)GetValue(GestureBindingProperty);
            set => SetValue(GestureBindingProperty, value);
        }

        // events
        private static void OnCommandBindingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var keyBinding = (RelayGestureBinding)d;
            keyBinding.Command = (RelayCommand)e.NewValue;
        }

        private static void OnGestureBindingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var keyBinding = (RelayGestureBinding)d;
            if (e.NewValue is KeyGesture keyGesture)
            {
                keyBinding.Key = keyGesture.Key;
                keyBinding.Modifiers = keyGesture.Modifiers;
            }
        }
    }
}
