using System;
using Avalonia.VisualTree;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia.Controls;
using Mapsui.Extensions;
using Mapsui.Layers;
using Mapsui;
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
    public partial class Search : UserControl
    {
        // Mapping specific #################################################################
        private MyLocationLayer? _myLocationLayer;
        private bool isRunning = false;
        private Mapsui.Map? _map;
        private List<Climb> climbs;

        private string selectedRouteId;

        public string Name => "MyLocationLayer";
        public string Category => "Navigation";
        //###################################################################################

        
        
        public Search()
        {
            InitializeComponent();
            this.Loaded += async (sender, args) => await InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            await CreateMapAsync();
            await DisplayClimbPoints();

            await StartTrackingAsync();
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
                    //Console.WriteLine($"Location error: {ex.Message}");
                    if (_myLocationLayer != null)
                    {
                        var sphericalMercatorCoordinate = SphericalMercator.FromLonLat(-93.664905, 41.950914).ToMPoint();

                        _myLocationLayer.UpdateMyLocation(sphericalMercatorCoordinate, true);
                        _myLocationLayer.IsCentered = true;

                        _map.Home = n => n.CenterOnAndZoomTo(sphericalMercatorCoordinate, n.Resolutions[9]);
                    }
                }

                // Update every 5 seconds
                _map?.RefreshGraphics();
                await Task.Delay(5000);
            }
        }

        public async Task GetDirectionsAsync()
        {
            Climb selected;
            if(selectedRouteId != null) {
                selected = climbs.Where(c => c.RouteId.Equals(selectedRouteId)).FirstOrDefault();
                if (selected == null)
                {
                    return;   
                }

                //System.Console.WriteLine(selected.ParentLocation.Lat);
                //System.Console.WriteLine(selected.ParentLocation.Long);

                var currentPos = _myLocationLayer.MyLocation;
                (double lon, double lat) = SphericalMercator.ToLonLat(currentPos.X, currentPos.Y);
                var coordinates = new List<List<double>>
                {
                    new List<double> { lon, lat },
                    new List<double> { selected.ParentLocation.Long, selected.ParentLocation.Lat }
                };
                var route = await HelperFunction.LoginFunctions.GetDirectionsAsync(coordinates);
                if (route == null)
                {
                    return;
                }

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
                    MapView.RefreshGraphics();
                    _map.Home = n => n.CenterOnAndZoomTo(routeLayer.Extent.Centroid, 200);
                }
            } 
        }

        public async Task DisplayClimbPoints()
        {
            climbs = await API_Climbs.GetAllClimbsAsync("api/ClimbsDB");
            _map.Layers.Add(CreatePointLayer(climbs));
            _map.Info += MapOnInfo;
            _map.Widgets.Add(new MapInfoWidget(_map));
        }
        public async Task CreateMapAsync()
        {
            _map = new Mapsui.Map();
            _map.Navigator.OverrideZoomBounds = new MMinMax(0,20000);
            _map.Layers.Add(OpenStreetMap.CreateTileLayer());
            MapView.Map = _map;
        }

        public static IStyle CreateLineStringStyle()
        {
            return new VectorStyle
            {
                Fill = null,
                Outline = null,
                Line = { Color = Color.FromString("Red"), Width = 8 }
            };
        }

        private async void MapOnInfo(object? sender, Mapsui.MapInfoEventArgs e)
        {
            var calloutStyle = e.MapInfo?.Feature?.Styles.Where(s => s is CalloutStyle).Cast<CalloutStyle>().FirstOrDefault();
            if (calloutStyle != null)
            {
                calloutStyle.Enabled = !calloutStyle.Enabled;
                e.MapInfo?.Layer?.DataHasChanged();
            }
            selectedRouteId = e.MapInfo?.Feature?["RouteId"]?.ToString();
            if (string.IsNullOrEmpty(selectedRouteId))
            return;

            await GetDirectionsAsync();
        }

        private MemoryLayer CreatePointLayer(List<Climb> climbs)
        {
            return new MemoryLayer
            {
                Name = "Climbing locations with callouts",
                IsMapInfoLayer = true,
                Features = new MemoryProvider(GetClimbsFromBackend(climbs)).Features,
                Style = SymbolStyles.CreatePinStyle(symbolScale: 0.7),
            };
        }

        private static IEnumerable<Mapsui.IFeature> GetClimbsFromBackend(List<Climb> climbs)
        {
            return climbs.Select(c =>
            {
                var point = SphericalMercator.FromLonLat(c.ParentLocation.Long, c.ParentLocation.Lat).ToMPoint();
                var feature = new PointFeature(point);

                feature[nameof(Climb.RouteName)] = c.RouteName;
                feature[nameof(Climb.RouteId)] = c.RouteId;
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
                TitleFontColor = Color.Blue,
                MaxWidth = 180,
                RectRadius = 10,
                ShadowWidth = 4,
                Enabled = false,
                SymbolOffset = new Offset(0, SymbolStyle.DefaultHeight * 1f)
            };
        }

        public void LogOutButtonClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e) {
            var window = this.GetVisualRoot() as Window;
            var newWindow = new Login();
            Program.loggedInUser.UserId = "NOT_LOGGED_IN";
            Program.loggedInUser.Name = "NOT_LOGGED_IN";
            Program.loggedInUser.Email = "NOT_LOGGED_IN";
            Program.loggedInUser.Password = "NOT_LOGGED_IN";
            newWindow.Show();
            window?.Close();
        }
    }
}
