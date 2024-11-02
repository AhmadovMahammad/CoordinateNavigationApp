using System.Windows.Input;

namespace CoordinateNavigation.Constants
{
    public static class GestureBindings
    {
        public static readonly KeyGesture ToggleCoordinateTypeGesture = new(Key.Space, ModifierKeys.Control);
        public static readonly KeyGesture ConvertCoordinateGesture = new(Key.Enter, ModifierKeys.Control);
        public static readonly KeyGesture ViewInMapGesture = new(Key.M, ModifierKeys.Control);
        public static readonly KeyGesture CopyGesture = new(Key.C, ModifierKeys.Control);
        public static readonly KeyGesture ClearGesture = new(Key.N, ModifierKeys.Control);
        public static readonly KeyGesture ToggleAutoConversionGesture = new(Key.F, ModifierKeys.Control);
    }
}
