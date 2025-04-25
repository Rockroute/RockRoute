using System;
using System.ComponentModel;
using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.VisualTree;
using Avalonia.Markup.Xaml;

using RockRoute.Models;
using RockRoute.Classes;
using RockRoute.Helper;
using RockRoute.enums;
using System.Threading.Tasks;

namespace RockRoute.Views
{
    public partial class CreateAccount : Window
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            //Linking the textboxes across:
            NameBox = this.FindControl<TextBox>("NameBox");
            EmailBox = this.FindControl<TextBox>("EmailBox");
            PasswordBox = this.FindControl<TextBox>("PasswordBox");
            CPasswordBox = this.FindControl<TextBox>("CPasswordBox");

            //Linking the text across:
            PasswordError = this.FindControl<TextBlock>("PasswordError");


        }

        private void GotAccountButton(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {

            //This is all okay and works
            var NewWindow = new Login();
            if (!Program.DebugMode)
            {
                NewWindow.WindowState = WindowState.Maximized; //Uncomment this, This is just so i need minimise all the time to see debugger
            }
            NewWindow.Show();
            this.Close();
        }

        private async void CreateAccountButtonClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {

            if (!(NameBox.Text == null || EmailBox.Text == null || PasswordBox.Text == null || CPasswordBox.Text == null))
            {
                //If all boxes has something inside:

                if ((NameBox.Text.Length > 3))
                {
                    //If the name is longer than 3 characters
                    login_Status createAccountStatus = await LoginFunctions.CreateAccountFunc(NameBox.Text, EmailBox.Text, PasswordBox.Text, CPasswordBox.Text);
                    System.Console.WriteLine(createAccountStatus);

                    if (createAccountStatus == login_Status.Account_Created)
                    {
                        //If the account is created succesfully then attempt to login
                        //Doing this rather than auto log so it morebuilding on functions ive made (Easier to change if needed)
                        //and adds the user to the global LoggedInUser var

                        //Login attempt
                        login_Status LoginStatus = await LoginFunctions.LoginAccount(EmailBox.Text, PasswordBox.Text);
                        System.Console.WriteLine("Login Status: " + LoginStatus);
                        
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

                    if (createAccountStatus == login_Status.Passwords_Dont_Match)
                    {
                        PasswordError.Text = "Passwords must match";
                    }
                    if (createAccountStatus == login_Status.Account_Already_Exists)
                    {
                        PasswordError.Text = "Account Already Exists";
                    }





                }
                else
                {
                    PasswordError.Text = "Name must be more than 3 Characters";
                }

            }
            else
            {
                PasswordError.Text = "Please fill in all boxes";

            }






        }
    }
}