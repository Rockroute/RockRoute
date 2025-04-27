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

            var lonLat = new[]
            {
                new[] { inputCoordinates[0][0], inputCoordinates[0][1] },
                new[] { inputCoordinates[1][0], inputCoordinates[1][1] }
            };

            var payload = new
            {
                coordinates = lonLat,
                radiuses = new int[] {-1}
            };
            var json = JsonSerializer.Serialize(payload);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://api.openrouteservice.org/v2/directions/driving-car/geojson"),
                Headers =
                {
                    { "Accept",        "application/json, application/geo+json" },
                    { "Authorization", "APIKEYHERE" }
                },
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            try
            {
                using var response = await client.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"ORS returned {(int)response.StatusCode}: {response.ReasonPhrase}");
                    return null;
                }

                var body = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(body);

                if (doc.RootElement.TryGetProperty("features", out var features) &&
                    features.GetArrayLength() > 0)
                {
                    var coords = features[0]
                        .GetProperty("geometry")
                        .GetProperty("coordinates");

                    var pts = new List<Coordinate>();
                    foreach (var coord in coords.EnumerateArray())
                    {
                        pts.Add(new Coordinate(
                            coord[0].GetDouble(),
                            coord[1].GetDouble()
                        ));
                    }
                    return new LineString(pts.ToArray());
                }

                Console.WriteLine("No features or geometry found.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during ORS request or parsing: {ex.Message}");
                return null;
            }
        }
    }
}
