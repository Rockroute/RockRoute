using System;
using System.ComponentModel;
using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.VisualTree;
using Avalonia.Markup.Xaml;

using RockRoute.Models;
using RockRoute.Classes;

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
            /*
            RockRoute.Classes.Activity Test = new RockRoute.Classes.Activity("Hello", null, "HE");
            if (Test.Name == "Hello")
            {
                Console.WriteLine("TEST World!");

            }
            */
            
            var NewWindow = new MainWindow();
           //NewWindow.WindowState = WindowState.Maximized; //Uncomment this, This is just so i need minimise all the time to see debugger
            NewWindow.Show();
            this.Close();
        }
    }
}