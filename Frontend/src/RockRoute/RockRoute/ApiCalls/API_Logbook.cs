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
    class API_Logbooks

    {
        
        private static readonly string _baseAPIUrl = Program.runOn;

        static HttpClientHandler handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        };

        static HttpClient client = new HttpClient(handler);

        

        public static async Task<Uri> CreateLogbookAsync(LogBook logBook)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync($"{_baseAPIUrl}api/LogBookDB", logBook);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        public static async Task<LogBook> GetLogbookAsync(string path)
        {
            LogBook LogBook = null;
            HttpResponseMessage response = await client.GetAsync($"{_baseAPIUrl}{path}");
            if (response.IsSuccessStatusCode)
            {
                LogBook = await response.Content.ReadFromJsonAsync<LogBook>();
            }
            return LogBook;
        }
        public static async Task<List<LogBook>> GetAllLogbooksAsync(string path)
        {
            List<LogBook>? LogBook = new();
            HttpResponseMessage response = await client.GetAsync($"{_baseAPIUrl}{path}");
            if (response.IsSuccessStatusCode)
            {
                LogBook = await response.Content.ReadFromJsonAsync<List<LogBook>>();
            }
            return LogBook ?? new List<LogBook>(); //Will return the logbooks or if null return a empty list
        }

        public static async Task<LogBook> UpdateLogbookAsync(LogBook logBook)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"{_baseAPIUrl}api/LogBookDB/{logBook.UserId}", logBook);
            response.EnsureSuccessStatusCode();

            if (response.Content.Headers.ContentLength == 0)
            {
                return logBook;
            }
            else
            {
                return await response.Content.ReadFromJsonAsync<LogBook>() ?? logBook;
            }
        }

        public static async Task<HttpStatusCode> DeleteLogbookAsync(string UserId)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{_baseAPIUrl}api/LogBookDB/{UserId}");
            return response.StatusCode;
        }
       
    }
}