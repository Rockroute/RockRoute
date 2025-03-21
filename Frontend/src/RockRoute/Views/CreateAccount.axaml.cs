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

namespace RockRoute.Views 
{
    public partial class CreateAccount : Window
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }

        private void GotAccountButton(object? sender, Avalonia.Interactivity.RoutedEventArgs e) {
            var NewWindow = new Login();
           //NewWindow.WindowState = WindowState.Maximized; //Uncomment this, This is just so i need minimise all the time to see debugger
            NewWindow.Show();
            this.Close();
        }

        private void CreateAccountButtonClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e) 
        {

            System.Console.WriteLine(LoginFunctions.CreateAccount("NEWUSER?A?!?!?", "NerUsersEmail", "newUsersPassword", "newUsersPassword"));

            var NewWindow = new MainWindow();
           //NewWindow.WindowState = WindowState.Maximized; //Uncomment this, This is just so i need minimise all the time to see debugger
            NewWindow.Show();
            this.Close();
        }
    }
}