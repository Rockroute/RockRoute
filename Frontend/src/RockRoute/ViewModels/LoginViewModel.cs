using RockRoute.Models;
using RockRoute.Classes;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using System.Windows.Input;



namespace RockRoute.ViewModels
{
    //Class named LoginViewModel Extends from BaseViewModel
    public class LoginViewModel : BaseViewModel
    {

        public ICommand LoginQuerySubmitCommand { get; }//Binding button in viewmodel to Method

        public LoginViewModel()
        {
            LoginQuerySubmitCommand = new AsyncRelayCommand(OnLoginQuerySubmitCommand);
        }
        public async Task OnLoginQuerySubmitCommand()
        {
            //Process here
        }

        public void PrintLogBookObject()
        {
            //System.Console.WriteLine(HelloKitt);
            LogBookConvert();
        }

        private string _username;
        public string Username
        {

            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(Username);
                }
            }
        }
        private string _password;
        public string Password
        {

            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(Password);
                }
            }

        }

    }
}