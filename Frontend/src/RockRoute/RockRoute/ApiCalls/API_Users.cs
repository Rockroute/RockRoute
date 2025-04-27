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
    class API_Users

    {
        private static readonly string _baseAPIUrl = Program.runOn;

        static HttpClientHandler handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        };

        static HttpClient client = new HttpClient(handler);

        static void ShowUser(User user)
        {
            Console.WriteLine($"Name: {user.Name}\tPrice: {user.Name}\tCategory: {user.Name}");
        }

        public static async Task<Uri> CreateUserAsync(User user)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync($"{_baseAPIUrl}api/UsersDB", user);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        public static async Task<User> GetUserAsync(string path)
        {
            User user = null;
            HttpResponseMessage response = await client.GetAsync($"{_baseAPIUrl}{path}");
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadFromJsonAsync<User>();
            }
            return user;
        }
        public static async Task<List<User>> GetAllUsersAsync(string path)
        {
            List<User>? user = new();
            HttpResponseMessage response = await client.GetAsync($"{_baseAPIUrl}{path}");
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadFromJsonAsync<List<User>>();
            }
            return user ?? new List<User>(); //Will return the users or if null return a empty list
        }

        public static async Task<User> UpdateUserAsync(User user)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"{_baseAPIUrl}api/UsersDB/{user.UserId}", user);
            response.EnsureSuccessStatusCode();
            user = await response.Content.ReadFromJsonAsync<User>();
            return user;
        }

        public static async Task<HttpStatusCode> DeleteUserAsync(string UserId)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{_baseAPIUrl}api/UsersDB/{UserId}");
            return response.StatusCode;
        }

        public static async Task RunAsync()
        {
            try
            {
                User newUser = new User
                {
                    UserId = "TEST",
                    Name = "NAME",
                    Email = "EMAIL",
                    Password = "PASSWORD"
                };

                var url = await CreateUserAsync(newUser);
                Console.WriteLine($"Created at {url}");

                newUser = await GetUserAsync(url.AbsolutePath);
                ShowUser(newUser);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}