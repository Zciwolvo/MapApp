using Avalonia.Controls;
using Mapsui.Geometries;
using Mapsui.Layers;
using Mapsui.Projection;
using Mapsui.Projections;
using Mapsui.Styles;
using Mapsui.Tiling;
using Mapsui.UI.Avalonia;
using Mapsui.UI.Avalonia.Extensions;
using NetTopologySuite.Geometries;

public class MainWindow : Window
{
    public MainWindow()
    {
        // Create a new MapControl
        var mapControl = new MapControl();

        // Create a new VectorLayer to hold the path data
        var pathLayer = new VectorLayer("Path");

        // Create a new LineString to represent the path
        var pathGeometry = new LineString(new[] { SphericalMercator.FromLonLat(new Point(Ax, Ay)), SphericalMercator.FromLonLat(new Point(Bx, By)) });

        // Create a new Feature to hold the LineString
        var pathFeature = new Feature { Geometry = pathGeometry };

        // Add the Feature to the VectorLayer
        pathLayer.Features.Add(pathFeature);

        // Add the VectorLayer to the MapControl
        mapControl.Map.Layers.Add(pathLayer);

        // Add an OpenStreetMap tile layer to the MapControl
        mapControl.Map.Layers.Add(OpenStreetMap.CreateTileLayer());

        // Set the initial map extent
        mapControl.Map.NavigateTo(SphericalMercator.FromLonLat(new Point(Ax, Ay)), mapControl.Map.Resolutions[10]);

        // Add the MapControl to the window
        Content = mapControl;
    }
}
