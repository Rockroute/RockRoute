using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic; //For List


using RockRoute.Classes;
using RockRoute.Models;
using RockRoute.enums;

namespace RockRoute.ApiTest
{
    class APIprogram
    
    {
        private static readonly string _baseAPIUrl = "http://localhost:5297/";

        static HttpClientHandler handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        };

        static HttpClient client = new HttpClient(handler);

        static void ShowClimb(Climb climb)
        {
            Console.WriteLine($"Name: {climb.RouteName}\tPrice: {climb.RouteName}\tCategory: {climb.RouteName}");
        }

        public static async Task<Uri> CreateClimbAsync(Climb climb)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync($"{_baseAPIUrl}api/ClimbsDB", climb);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        public static async Task<Climb> GetClimbAsync(string path)
        {
            Climb climb = null;
            HttpResponseMessage response = await client.GetAsync($"{_baseAPIUrl}{path}");
            if (response.IsSuccessStatusCode)
            {
                climb = await response.Content.ReadFromJsonAsync<Climb>();
            }
            return climb;
        }
        public static async Task<List<Climb>> GetAllClimbsAsync(string path)
        {
            List<Climb>? climb = new();
            HttpResponseMessage response = await client.GetAsync($"{_baseAPIUrl}{path}");
            if (response.IsSuccessStatusCode)
            {
                climb = await response.Content.ReadFromJsonAsync<List<Climb>>();
            }
            return climb ?? new List<Climb>(); //Will return the climbs or if null return a empty list
        }

        public static async Task<Climb> UpdateClimbAsync(Climb climb)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"{_baseAPIUrl}api/ClimbsDB/{climb.RouteId}", climb);
            response.EnsureSuccessStatusCode();
            climb = await response.Content.ReadFromJsonAsync<Climb>();
            return climb;
        }

        public static async Task<HttpStatusCode> DeleteClimbAsync(string routeId)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{_baseAPIUrl}api/ClimbsDB/{routeId}");
            return response.StatusCode;
        }

        public static async Task RunAsync()
        {
            try
            {
                Climb climb = new Climb
                {
                    RouteName = "TheRouteName",
                    RouteId = "LSOSAY",
                    SectorId = "djs8d",
                    ParentSector = "ClimbSector",
                    Type = climbTypes.Boulder,
                    YDS = "V2",
                    ParentLocation = (37.733, -119.637),
                    LocationDescription = "Description of a climb",
                    Protection_Notes = "Bring snacks",
                    UserRatings = new List<CRating>()
                };

                var url = await CreateClimbAsync(climb);
                Console.WriteLine($"Created at {url}");

                climb = await GetClimbAsync(url.AbsolutePath);
                ShowClimb(climb);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
