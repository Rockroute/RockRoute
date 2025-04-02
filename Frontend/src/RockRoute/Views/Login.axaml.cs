using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Threading.Tasks;
using Newtonsoft.Json;

using RockRoute.Helper;
using RockRoute.enums;
using RockRoute.ViewModels;
using RockRoute.Classes;
using RockRoute.Models;

//Following Usings are temp and will be moved to helper
using System;
using System.Collections.Generic; //For List
using RockRoute.ApiTest;


namespace RockRoute.Views
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            DataContext = new LoginViewModel(); //Connects ViewModel to View
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        //Start of backend Testing Stuff

        Climb Testclimb = new Climb
        {
            RouteName = "TheRouteName",
            RouteId = "LSOSAY",
            SectorId = "djs8d",
            ParentSector = "ClimbSector",
            Type = climbTypes.Boulder,
            YDS = "V2",
            ParentLocation = (37.733, -119.637),
            LocationDescription = "Description of a climb",
            Protection_Notes = "Bring snacks",
            UserRatings = new List<CRating>()
        };
        private void DeleteClimb(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {

            System.Console.WriteLine("Delete");
        }
        private void GetAllClimbs(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {

        }
        private void GetAClimb(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {

        }
        private async void SaveAClimb(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var url = await APIprogram.CreateClimbAsync(Testclimb);
        }
        //End of the backend testing stuff, If you want it gone just just do one comments block shown as ->     /* The code in here  */


        private void NeedAccountButton(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var NewWindow = new CreateAccount();
            //NewWindow.WindowState = WindowState.Maximized; //Uncomment this, This is just so i need minimise all the time to see debugger
            NewWindow.Show();
            this.Close();

        }
    }
}
