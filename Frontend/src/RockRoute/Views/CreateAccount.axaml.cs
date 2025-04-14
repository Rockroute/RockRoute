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
            login_Status createAccountStatus = await LoginFunctions.CreateAccountFunc(NameBox.Text, EmailBox.Text, PasswordBox.Text, CPasswordBox.Text);
            System.Console.WriteLine(createAccountStatus);

            if (createAccountStatus == login_Status.Account_Created)
            {
                //if account created succesfully, then login:

                var NewWindow = new MainWindow();
                if (!Program.DebugMode) //Debug mode
                {
                    NewWindow.WindowState = WindowState.Maximized; //Uncomment this, This is just so i need minimise all the time to see debugger
                }

                //NewWindow.WindowState = WindowState.Maximized; //Uncomment this, This is just so i need minimise all the time to see debugger
                NewWindow.Show();
                this.Close();
            }


        }
    }
}