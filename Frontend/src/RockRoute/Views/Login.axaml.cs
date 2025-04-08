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
        //Simple way of hiding buttons and can be used for future
        void hideButtonDebug(string ButtonName)
        {
            if (!Program.DebugMode) //From the program.cs file
            {
                //If NOT in debug mode, hide button
                var hideButton = this.FindControl<Button>(ButtonName);
                hideButton.IsVisible = false;
            }
        }
        public Login()
        {
            InitializeComponent();
            DataContext = new LoginViewModel(); //Connects ViewModel to View

            //Hides buttons if debug mode is on, It follows the name not the click from .axaml.cs
            hideButtonDebug("Temp1");
            hideButtonDebug("Temp2");
            hideButtonDebug("Temp3");
            hideButtonDebug("Temp4");
            hideButtonDebug("Temp5");

            //Need to get the text from the email and password box
            EmailTxtBox = this.FindControl<TextBox>("EmailTxtBox");
            //Todo Put the code for password box here
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        //############################################################
        //############################################################
        //############################################################
        //############################################################
        //
        //Start of backend Testing Stuff
        //If your curious what Im doing here
        //Im just testing them all out here in the buttons at the login
        //When they work Ill then move the code below into a helper function
        //where the data will be processed there and passed into here easily
        //This makes it all look nicer and more effienct
        //
        //I have named them all temp and I regulary change the name and was getting confused
        //with number I can remeber what number I am working on at a time
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
        private async void Temp_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {

            login_Status createAdminStatus = await LoginFunctions.CreateAccountFunc("Admin", "Admin@Admin.com", "Admin", "Admin");

            System.Console.WriteLine("Admin Created, Name: Admin  Email:Admin@Admin.com   Pasword: Admin");
            System.Console.WriteLine(createAdminStatus);
        }
        private async void Temp_2(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {

            //bool doesitExist = await LoginFunctions.doesExist(EmailTxtBox.Text);
            //System.Console.WriteLine(doesitExist);

        }
        private async void Temp_3(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {

            System.Console.WriteLine("Get A");
            //This works
            Climb retrievedClimb = await API_Climbs.GetClimbAsync("api/ClimbsDB/LSOSAY");
            if (retrievedClimb != null)
            {
                System.Console.WriteLine(retrievedClimb.RouteName);
            }
            else
            {
                System.Console.WriteLine("Climb not found");
            }


        }
        private async void Temp_4(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            System.Console.WriteLine("Save A");
            //THIS WORKS
            var url = await API_Climbs.CreateClimbAsync(Testclimb);
        }
        //End of the backend testing stuff, If you want it gone just just do one comments block shown as ->     /* The code in here  */

        private void Temp_5(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            LoginFunctions.CreateAccountFunc("Admin", "Admin@Admin.gmail.com", "Admin", "Admin");

            var NewWindow = new MainWindow();
            if (!Program.DebugMode)
            {
                NewWindow.WindowState = WindowState.Maximized; //Uncomment this, This is just so i need minimise all the time to see debugger
            }

            NewWindow.Show();
            this.Close();

        }
        //Above this line is debug stuff
        //############################################################
        //############################################################
        //############################################################
        //############################################################
        //############################################################
        //############################################################
        //############################################################


        private void LoginButton(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            //Login.LoginAccount(string email, string password)
            if (EmailTxtBox.Text == null)
            {
                System.Console.WriteLine("NULL");
            }
            System.Console.WriteLine(EmailTxtBox.Text);
            //string InputEmail = EmailTxtBox.Text;

            //System.Console.WriteLine(InputEmail);
            //System.Console.WriteLine(PasswordTxtBox.Text);

            /*
                        if (LoginFunctions.LoginAccount(EmailTxtBox.Text, PasswordTxtBox.Text) == login_Status.Successfull_Login)
                        {
                            var NewWindow = new MainWindow();
                            if (!Program.DebugMode)
                            {
                                NewWindow.WindowState = WindowState.Maximized; //Uncomment this, This is just so i need minimise all the time to see debugger
                            }

                            NewWindow.Show();
                            this.Close();

                        }

                        */


        }


        private void NeedAccountButton(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var NewWindow = new CreateAccount();
            if (!Program.DebugMode)
            {
                NewWindow.WindowState = WindowState.Maximized; //Uncomment this, This is just so i need minimise all the time to see debugger
            }

            NewWindow.Show();
            this.Close();

        }
    }
}
