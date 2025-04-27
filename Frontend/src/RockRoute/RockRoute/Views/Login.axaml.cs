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
using RockRoute.climbData;
using RockRoute.ApiCalls;


namespace RockRoute.Views
{


    public partial class Login : Window
    {

        private CheckBox ShowPasswordCheckBox;
        //Of type check box to be used later on


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

            //Links the Textboxes across
            EmailTxtBox = this.FindControl<TextBox>("EmailTxtBox");
            PasswordBox = this.FindControl<TextBox>("PasswordBox");
            PasswordError = this.FindControl<TextBlock>("PasswordError");


            ShowPasswordCheckBox = this.FindControl<CheckBox>("CheckBox");
            //Assigns the variable to link accross to the axaml

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }


        private async void LoginButton(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            //Login.LoginAccount(string email, string password)
            if (!(EmailTxtBox.Text == null || PasswordBox.Text == null))
            {

                //System.Console.WriteLine(EmailTxtBox.Text);
                //System.Console.WriteLine(PasswordBox.Text);

                //string InputEmail = EmailTxtBox.Text;
                login_Status LoginStatus = await LoginFunctions.LoginAccount(EmailTxtBox.Text, PasswordBox.Text);
                //System.Console.WriteLine("Login Status: " + LoginStatus);
                //System.Console.WriteLine(InputEmail.ToLower());
                //System.Console.WriteLine(PasswordTxtBox.Text);

                if (LoginStatus == login_Status.Account_Does_Not_Exists)
                {
                    PasswordError.Text = "Account Does Not Exist";
                }
                if (LoginStatus == login_Status.Incorrect_Details)
                {
                    PasswordError.Text = "Incorrect Details";
                }


                if (LoginStatus == login_Status.Successfull_Login)
                {
                    var NewWindow = new MainWindow();
                    if (!Program.DebugMode)
                    {
                        NewWindow.WindowState = WindowState.Maximized; //Uncomment this, This is just so i need minimise all the time to see debugger
                    }

                    NewWindow.Show();
                    this.Close();

                }
            }
            else
            {
                //If one of the text boxes are empty
                //System.Console.WriteLine("NULL");
                PasswordError.Text = "Fill in all information";
            }





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

        //ShowPassword currently works for:
        //obscuring password without check box interaction
        //changing obscured password to letters once checked 
        //--- doesn't change them back instantly once unnchecked, have to delete all typed characters first then retype (think it's a feature with RevealPassword)

        public bool RevealPassword { get; set; }
        public void ShowPassword(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (ShowPasswordCheckBox.IsChecked == true)
            {
                RevealPassword = true;
            }
            else
            {
                RevealPassword = false;
            }
            PasswordBox.RevealPassword = RevealPassword;
        }











        //Anything below here doesnt have functionality but is for easily debug stuff
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
        //I have named them all temp and I regulary change the name and was getting confused
        //with number I can remeber what number I am working on at a time

        private async void Temp_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            ProcessData.createAndPushData();

        }
        private async void Temp_2(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {



        }
        private async void Temp_3(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {

        }
        private async void Temp_4(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {


        }

        private void Temp_5(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {

        }
        //Above this line is debug stuff
        //############################################################
        //############################################################
        //############################################################
        //############################################################
        //############################################################

    }
}
