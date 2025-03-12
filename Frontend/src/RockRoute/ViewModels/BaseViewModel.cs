using System.Net.Http;
using System.ComponentModel;
using RockRoute.Classes;
using System.Text.Json.Serialization;
using System.Text.Json;


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

        public void LogBook()
        {

            
            /*
            What the API returns
            {
            "userId": "string",
            "routeId": "string",
            "playlist": "string",
            "route": "string",
            "activity": "string",
            "user": "string",
            "climb": "string"
            }
            
            //repace this with the API call
            var jsonData = new
            {
                userId = "string",
                routeId = "string",
                playlist = "string",
                route = "string",
                activity = "string",
                user = "string",
                climb = "string"
            };

            var LogBookData = JsonSerializer.Deserialize<RockRoute.Models.LogBook>(jsonData);
            //System.Console.WriteLine(LogBookData.RouteID);
            */
        }
    }
}
