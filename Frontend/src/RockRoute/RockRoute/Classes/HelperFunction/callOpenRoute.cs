using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NetTopologySuite.Geometries;
using System.Web;
using NetTopologySuite.IO;
using System.Linq;
using Mapsui.Nts.Extensions;
using Mapsui.Projections;


namespace RockRoute.HelperFunction
{
    public static class LoginFunctions
    {
            public static async Task<LineString?> GetDirectionsAsync(List<List<double>> inputCoordinates)
            {
                using var client = new HttpClient();

                var startCoordinates = $"{inputCoordinates[0][0]},{inputCoordinates[0][1]}"; // Longitude, Latitude
                var endCoordinates = $"{inputCoordinates[1][0]},{inputCoordinates[1][1]}"; // Longitude, Latitude

                var requestUri = $"https://api.openrouteservice.org/v2/directions/driving-car?start={HttpUtility.UrlEncode(startCoordinates)}&end={HttpUtility.UrlEncode(endCoordinates)}";

                // Set up the HTTP request
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get, 
                    RequestUri = new Uri(requestUri),
                    Headers =
                    {
                        { "Accept", "application/json, application/geo+json, application/gpx+xml, img/png; charset=utf-8" },
                        { "Authorization", "APIKEYHERE" } 
                    }
                };

                try
                {
                    // Send the request and get response
                    using var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    var returnBody = await response.Content.ReadAsStringAsync();

                    using (JsonDocument doc = JsonDocument.Parse(returnBody))
                    {
                        // Ensure the features array exists and has elements
                        if (doc.RootElement.TryGetProperty("features", out var features) && features.GetArrayLength() > 0)
                        {
                            var feature = features[0];
                            if (feature.TryGetProperty("geometry", out var geometry) &&
                                geometry.TryGetProperty("coordinates", out var coordinates))
                            {
                                var points = new List<Coordinate>();

                                // Iterate through the coordinates and add them as Coordinates to the list
                                foreach (var coordinate in coordinates.EnumerateArray())
                                {
                                    // Ensure the coordinates are in the correct order (Longitude, Latitude)
                                    double lon = coordinate[0].GetDouble();  // Longitude
                                    double lat = coordinate[1].GetDouble();  // Latitude
                                    points.Add(new Coordinate(lon, lat));  
                                }
                                return new LineString(points.ToArray());
                            }
                            else
                            {
                                Console.WriteLine("No geometry or coordinates found in the feature.");
                                return null;
                            }
                        }
                        else
                        {
                            Console.WriteLine("No features found in the API response.");
                            return null;
                        }
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request error: {e.Message}");
                    return null;
                }
                catch (JsonException e)
                {
                    Console.WriteLine($"JSON parsing error: {e.Message}");
                    return null;
                }
            }
    }
}
