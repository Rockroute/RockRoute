using System.Net.Http;
using System.ComponentModel;
using RockRoute.Classes;
using RockRoute.Models;
using Newtonsoft.Json;



//This is generic code for the views 
namespace RockRoute.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected HttpClient _httpClient;
        protected string _baseApiUrl;

        public string HelloKitt = "HEllo";
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public BaseViewModel()
        {
            _httpClient = new HttpClient();
        }

        public void LogBookConvert()
        {
            //Converts the json inti a Logbook object
            var theApiCall = new //Replace this with what the API returns
            {
                userId = "string",
                routeId = "string",
                playlist = "string",
                route = "string",
                activity = "string",
                user = "string",
                climb = "string"
            };
    
            //string ApiAsString = JsonConvert.SerializeObject(theApiCall); //Converts the ApiJson into JSON String
            //System.Console.WriteLine(ApiAsString); //Prints the JSON string
            
            
        }
    }
}
