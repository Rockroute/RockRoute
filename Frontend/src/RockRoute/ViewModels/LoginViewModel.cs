using RockRoute.Models;
using RockRoute.Classes;

namespace RockRoute.ViewModels
{
    //Class named LoginViewModel Extends from BaseViewModel
    public class LoginViewModel : BaseViewModel
    {

        public LoginViewModel()
        {
            //Console.WriteLine(HelloKitt);

        }
        public void Hello12()
        {
            System.Console.WriteLine(HelloKitt);
        }

        private string _username;
        public string Username {

            get => _username;
            set {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(Username);
                }
            }
        }
        private string _password;
        public string Password {

            get => _password;
            set {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(Password);
                }
            }
        }

    }

}