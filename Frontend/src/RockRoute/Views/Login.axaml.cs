using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RockRoute.ViewModels;
using RockRoute.Classes;
using Newtonsoft.Json;
using RockRoute.Helper;
using RockRoute.enums;
using RockRoute.ApiCall;



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

        //Harveys Magic Print Button
        private async void TestTheCroute(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            //await APIprogram.RunAsync();

        }

        private void NeedAccountButton(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var NewWindow = new CreateAccount();
           //NewWindow.WindowState = WindowState.Maximized; //Uncomment this, This is just so i need minimise all the time to see debugger
            NewWindow.Show();
            this.Close();

        }
    }
}
