using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Mapsui;
using Mapsui.Layers;
using Mapsui.Styles;
using Mapsui.UI.Avalonia;
using Mapsui.Geometries;


namespace MapsApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
        }

        private PointLatLng start;
        private PointLatLng end;

        private void OnMapPointerPressed(object sender, PointerPressedEventArgs e)
        {
            // Get the clicked point on the map
            var point = mapControl.ConvertPoint(e.GetPosition(mapControl), mapControl);

            if (start == null)
            {
                // Set the start point
                start = point;
            }
            else if (end == null)
            {
                // Set the end point
                end = point;

                // Draw the path between the two points
                DrawPath(start, end);

                // Reset the start and end points
                start = null;
                end = null;
            }
        }

        private void DrawPath(PointLatLng start, PointLatLng end)
        {
            // Create a new map layer
            var layer = new Mapsui.Layers.Layer();

            // Create a new line feature
            var line = new Mapsui.Geometries.LineString(new[] { start, end });

            // Create a new style for the line
            var style = new Mapsui.Styles.VectorStyle
            {
                Line = new Mapsui.Styles.Pen
                {
                    Color = Mapsui.Styles.Color.Red,
                    Width = 2
                }
            };

            // Add the line feature to the layer
            layer.DataSource = new Mapsui.Data.FeatureCollection(new[] { new Mapsui.Data.Feature(line) });
            layer.Styles.Add(style);

            // Add the layer to the map
            mapControl.Map.Layers.Add(layer);
        }
    }
}
