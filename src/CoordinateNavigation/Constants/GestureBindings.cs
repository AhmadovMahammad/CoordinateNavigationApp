using System.Windows.Input;

namespace CoordinateNavigation.Constants
{
    public static class GestureBindings
    {
        public static readonly KeyGesture ToggleCoordinateTypeGesture = new(Key.Space, ModifierKeys.Control);
        public static readonly KeyGesture CopyGesture = new(Key.C, ModifierKeys.Control);
        public static readonly KeyGesture PasteGesture = new(Key.V, ModifierKeys.Control);
        public static readonly KeyGesture UndoGesture = new(Key.Z, ModifierKeys.Control);
        public static readonly KeyGesture RedoGesture = new(Key.Y, ModifierKeys.Control);
    }
}
