using System.Windows.Input;

namespace CoordinateNavigation.Constants
{
    public static class GestureBindings
    {
        public static readonly KeyGesture ToggleCoordinateTypeGesture = new KeyGesture(Key.Space, ModifierKeys.Control);
        public static readonly KeyGesture CopyGesture = new KeyGesture(Key.C, ModifierKeys.Control);
        public static readonly KeyGesture ViewInMapGesture = new KeyGesture(Key.M, ModifierKeys.Control);
        public static readonly KeyGesture ClearGesture = new KeyGesture(Key.N, ModifierKeys.Control);
        public static readonly KeyGesture SaveGesture = new KeyGesture(Key.S, ModifierKeys.Control);
    }
}
