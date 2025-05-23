using RockRoute.Models;
using RockRoute.Classes;
using RockRoute.Helper;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic; //to use List




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

        public void printTheCroute()
        {
            //Just temp data for testing creating an instance
            string routeID = "283hdk98";
            DateTime? completedDate = null;
            List<string>? partnerID = null;
            int? attempts = 3;
            bool? isOnSite = true;
            string? notes = "Interesting climb, Recommend";

            // Creating an instance
            //string ApiAsString = JsonConvert.SerializeObject(myRoute); //Converts the ApiJson into JSON String
            ////System.Console.WriteLine(ApiAsString); //Prints the JSON string

        }

        public bool checkUser(string inputUserName, string InputPassword)
        {

            return true;
        }


        public void PrintLogBookObject()
        {

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