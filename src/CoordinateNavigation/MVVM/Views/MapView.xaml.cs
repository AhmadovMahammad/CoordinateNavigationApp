using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CoordinateNavigation.MVVM.Views
{
    public partial class MapView : Window
    {
        private readonly double _latitude;
        private readonly double _longitude;

        public MapView(double latitude, double longitude)
        {
            InitializeComponent();

            _latitude = latitude;
            _longitude = longitude;
        }

        private void MapView_Loaded(object sender, RoutedEventArgs e)
        {
            GMaps.Instance.Mode = AccessMode.ServerAndCache;

            MapControl.MapProvider = GMapProviders.OpenStreetMap;
            MapControl.Position = new PointLatLng(_latitude, _longitude);
            MapControl.ShowCenter = false;

            MapControl.MinZoom = 2;
            MapControl.MaxZoom = 18;
            MapControl.Zoom = 10;

            MapControl.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            MapControl.CanDragMap = true;
            MapControl.DragButton = MouseButton.Left;

            AddMarker();
        }

        private void AddMarker()
        {
            PointLatLng position = new PointLatLng(_latitude, _longitude);
            GMapMarker marker = new GMapMarker(position)
            {
                Shape = new Ellipse()
                {
                    Width = 20,
                    Height = 20,
                    Stroke = Brushes.Navy,
                    StrokeThickness = 2,
                    Fill = Brushes.White
                },
            };

            var toolTip = new ToolTip() { Content = $"Lat: {_latitude}, Lng: {_longitude}" };
            ToolTipService.SetToolTip(marker.Shape, toolTip);

            MapControl.Markers.Add(marker);
        }
    }
}
