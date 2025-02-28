using System;
using System.ComponentModel;
using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.VisualTree;
using Avalonia.Markup.Xaml;

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
            NewWindow.WindowState = WindowState.Maximized;
            NewWindow.Show();
            this.Close();
        }

        private void CreateAccountButtonClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e) 
        {
            var NewWindow = new MainWindow();
            NewWindow.WindowState = WindowState.Maximized;
            NewWindow.Show();
            this.Close();
        }
    }
}