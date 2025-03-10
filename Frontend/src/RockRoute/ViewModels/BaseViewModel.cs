using System.Net.Http;
using System.ComponentModel;
//This is generic code for the views 
namespace RockRoute.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected HttpClient _httpClient;
        protected string _baseApiUrl;

        public string HelloKitt = "HEllo";
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public BaseViewModel() {
            _httpClient = new HttpClient();
        }
    }
}