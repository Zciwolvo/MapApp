using Avalonia;
using Avalonia.Controls;


namespace MapsApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var mapControl = new Mapsui.UI.Avalonia.MapControl();
            mapControl.Map?.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());
            Content = mapControl;
        }
    }
}
