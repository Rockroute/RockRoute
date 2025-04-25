using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia.Controls;
using Mapsui.Extensions;
using Mapsui.Layers;
using Mapsui.Nts;
using Mapsui.Nts.Extensions;
using Mapsui.Projections;
using Mapsui.Styles;
using Mapsui.Tiling;
using Mapsui.UI.Avalonia;
using NetTopologySuite.Geometries;
using RockRoute.HelperFunction;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
using RockRoute.ApiCalls;
using Mapsui.Providers;
using Mapsui.Widgets;
using System.Reflection;
using RockRoute.Models;



namespace RockRoute.Views
{
    public partial class TestMapping : Window
    {
        private MyLocationLayer? _myLocationLayer;
        private bool isRunning = false;
        private Mapsui.Map? _map;

        public string Name => "MyLocationLayer";
        public string Category => "Navigation";

        private static List<Climb> routes = new();


        public TestMapping()
        {
            InitializeComponent();
            CreateMapAsync();
            //StartTrackingAsync();
        }

        public async Task StartTrackingAsync()
        {
            isRunning = true;
            
            _myLocationLayer?.Dispose();
            _myLocationLayer = new MyLocationLayer(_map)
            {
                IsCentered = false,
            };
            _map.Layers.Add(_myLocationLayer);


            while (isRunning)
            {
                try
                {
                    var location = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Best,
                        Timeout = TimeSpan.FromSeconds(10)
                    });

                    if (location != null && _myLocationLayer != null)
                    {
                        var sphericalMercatorCoordinate = SphericalMercator.FromLonLat(location.Longitude, location.Latitude).ToMPoint();

                        _myLocationLayer.UpdateMyLocation(sphericalMercatorCoordinate, true);
                        _myLocationLayer.IsCentered = true;

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

        public async Task GetDirectionsAsync(string routeID)
        {
            var testCoordinates = new List<List<double>>
            {
                new List<double> { 8.681495, 49.41461 },
                new List<double> { 8.687872, 49.420318 }
            };
            var route = await HelperFunction.LoginFunctions.GetDirectionsAsync(testCoordinates);
            System.Console.WriteLine(route);

            var projectedCoordinates = route.Coordinates.Select(c => SphericalMercator.FromLonLat(c.X, c.Y).ToCoordinate()).ToArray();
            var lineString = new LineString(projectedCoordinates);

            if (route != null)
            {
                var routeLayer = new MemoryLayer
                {
                    Features = new[] { new GeometryFeature { Geometry = lineString } },
                    Name = "ORSRouteLayer",
                    Style = CreateLineStringStyle()
                };

                _map.Layers.Add(routeLayer);
                _map.Home = n => n.CenterOnAndZoomTo(routeLayer.Extent.Centroid, 200);
            }
        }

        public async Task DisplayClimbPoints()
        {
            _map.Layers.Add(CreatePointLayer());
            _map.Widgets.Add(new MapInfoWidget(_map));
        }
        public async void CreateMapAsync()
        {
            routes = await API_Climbs.GetAllClimbsAsync("api/ClimbsDB");
            _map = new Mapsui.Map();

            _map.Layers.Add(OpenStreetMap.CreateTileLayer());
            MapView.Map = _map;
        }
        
        public static IStyle CreateLineStringStyle()
        {
            return new VectorStyle
            {
                Fill = null,
                Outline = null,
                Line = { Color = Color.FromString("Red"), Width = 10 }
            };
        }

        /*private static void MapOnInfo(object? sender, MapInfoEventArgs e)
        {
            var calloutStyle = e.MapInfo?.Feature?.Styles.Where(s => s is CalloutStyle).Cast<CalloutStyle>().FirstOrDefault();
            if (calloutStyle != null)
            {
                calloutStyle.Enabled = !calloutStyle.Enabled;
                e.MapInfo?.Layer?.DataHasChanged(); // To trigger a refresh of graphics.
            }
        }*/

        private static MemoryLayer CreatePointLayer()
        {
            return new MemoryLayer
            {
                Name = "Cities with callouts",
                IsMapInfoLayer = true,
                Features = new MemoryProvider(GetClimbsFromBackend()).Features,
                Style = SymbolStyles.CreatePinStyle(symbolScale: 0.7),
            };
        }

        private static IEnumerable<Mapsui.IFeature> GetClimbsFromBackend()
        {

            return routes.Select(c =>
            {
                var point = SphericalMercator.FromLonLat(c.ParentLocation.Long, c.ParentLocation.Lat).ToMPoint();
                var feature = new PointFeature(point);

                feature[nameof(Climb.RouteName)] = c.RouteName;
                feature[nameof(Climb.RouteId)] = c.RouteId;
                feature[nameof(Climb.SectorId)] = c.SectorId;
                feature[nameof(Climb.ParentSector)] = c.ParentSector;
                feature[nameof(Climb.YDS)] = c.YDS;
                feature[nameof(Climb.Protection_Notes)] = c.Protection_Notes;

                feature.Styles.Add(CreateCalloutStyle(feature.ToStringOfKeyValuePairs()));
                
                return feature;
            });
        }

        private static CalloutStyle CreateCalloutStyle(string content)
        {
            return new CalloutStyle
            {
                Title = content,
                TitleFont = { FontFamily = null, Size = 12, Italic = false, Bold = true },
                TitleFontColor = Color.Gray,
                MaxWidth = 120,
                RectRadius = 10,
                ShadowWidth = 4,
                Enabled = false,
                SymbolOffset = new Offset(0, SymbolStyle.DefaultHeight * 1f)
            };
        }
    }
}
