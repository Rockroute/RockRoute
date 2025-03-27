using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic; //to use List


using RockRoute.Classes;
using RockRoute.Models;
using RockRoute.enums;

namespace RockRoute.ApiCall
{


    class APIprogram
    {

        
        static HttpClient client = new HttpClient();

        static void ShowClimb(Climb climb)
        {
            Console.WriteLine($"Name: {climb.RouteName}\tPrice: " +
                $"{climb.RouteName}\tCategory: {climb.RouteName}");
        }

        static async Task<Uri> CreateClimbAsync(Climb climb)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/ClimbsDB", climb);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task<Climb> GetClimbAsync(string path)
        {
            Climb climb = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                climb = await response.Content.ReadAsAsync<Climb>();
            }
            return climb;
        }

        static async Task<Climb> UpdateClimbAsync(Climb climb)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/ClimbsDB/{climb.RouteId}", climb);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated climb from the response body.
            climb = await response.Content.ReadAsAsync<Climb>();
            return climb;
        }

        static async Task<HttpStatusCode> DeleteClimbAsync(string routeId)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/ClimbsDB/{routeId}");
            return response.StatusCode;
        }

        /*static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }
*/
        public static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:5297");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Create a new climb
                Climb climb = new Climb
                {
                    RouteName = "TheRouteName",
                    RouteId = "LSOSAY", //No brackets in RouteID?
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

                // Get the climb
                climb = await GetClimbAsync(url.PathAndQuery);
                ShowClimb(climb);

                // Update the climb
                //Console.WriteLine("Updating price...");
                //climb.RouteName = "NEWNAME";
                //await UpdateClimbAsync(climb);

                // Get the updated climb
                //climb = await GetClimbAsync(url.PathAndQuery);
                //ShowClimb(climb);

                // Delete the climb
                //var statusCode = await DeleteClimbAsync(climb.RouteId);
                //Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}