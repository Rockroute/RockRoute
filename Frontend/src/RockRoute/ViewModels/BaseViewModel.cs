using System.Net.Http;
using System.ComponentModel;

namespace RockRoute.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected HttpClient _httpClient;
        protected string _baseApiUrl;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public BaseViewModel() {
            _httpClient = new HttpClient();
        }
    }
}