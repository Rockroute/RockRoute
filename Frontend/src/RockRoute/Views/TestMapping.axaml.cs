using Avalonia.Controls;
using RockRoute.ViewModels;
using Mapsui.Tiling;

namespace RockRoute.Views {
    public partial class TestMapping : Window
    {
        public TestMapping()
        {
            InitializeComponent();
            var mapControl = new Mapsui.UI.Avalonia.MapControl();
            mapControl.Map?.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());
            Content = mapControl;        
        }
    }
}