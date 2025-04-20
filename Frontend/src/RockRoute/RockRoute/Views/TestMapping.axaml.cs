using System;
using Mapsui.Extensions;
using Mapsui.Layers;
using Mapsui.Projections;
using Mapsui.Tiling;
using Mapsui.UI.Avalonia;
using Xamarin.Essentials;
using Avalonia.Controls;
using System.Threading.Tasks;

namespace RockRoute.Views
{
    public partial class TestMapping : Window
    {
        private MyLocationLayer? _myLocationLayer;
        
        private bool _isRunning = false;
        private Mapsui.Map? _map;

        public string Name => "MyLocationLayer";

        public string Category => "Navigation";

        public TestMapping()
        {
            InitializeComponent();
            CreateMapAsync();
            StartTrackingAsync(); 

        }

        // Method to start tracking GPS and update the location every 5 seconds
        public async Task StartTrackingAsync()
        {
            _isRunning = true;

            while (_isRunning)
            {
                try
                {
                    // Get the GPS location
                    var location = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Best,
                        Timeout = TimeSpan.FromSeconds(10)
                    });

                    if (location != null && _myLocationLayer != null)
                    {
                        // Convert GPS coordinates to spherical mercator coordinates
                        var sphericalMercatorCoordinate = SphericalMercator.FromLonLat(location.Longitude, location.Latitude).ToMPoint();

                        // Update the location on the map
                        _myLocationLayer.UpdateMyLocation(sphericalMercatorCoordinate, true);
                        _myLocationLayer.IsCentered = true;

                        // Optionally, update the map's center to the user's current location
                        // You can adjust the zoom level as needed
                        _map.Home = n => n.CenterOnAndZoomTo(sphericalMercatorCoordinate, n.Resolutions[9]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Location error: {ex.Message}");
                }

                // Update every 5 seconds
                await Task.Delay(5000);
            }
        }

        public void CreateMapAsync()
        {
            _map = new Mapsui.Map();

            _myLocationLayer?.Dispose();
            _myLocationLayer = new MyLocationLayer(_map)
            {
                IsCentered = false,
            };

            _map.Layers.Add(OpenStreetMap.CreateTileLayer());
            _map.Layers.Add(_myLocationLayer);
            MapView.Map = _map;

        }

        
    }
}
